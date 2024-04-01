using CDE_Web_API.Models;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

// For Entity Framework
builder.Services.AddDbContext<CDEDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString), ServiceLifetime.Singleton);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {tokent}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
// Adding Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("JWT:Secret").Value)),
            ValidateAudience = false,
            ValidateIssuer = false,
        };
    });

builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<AuthAccountService, AuthAccountServiceImpl>();
builder.Services.AddScoped<AreaService, AreaServiceImpl>();
builder.Services.AddScoped<DistributorService, DistributorServiceImpl>();
builder.Services.AddScoped<PositionTitleService, PositionTitleServiceImpl>();
builder.Services.AddScoped<VisitService, VisitServiceImpl>();
builder.Services.AddScoped<TaskService, TaskServiceImpl>();
builder.Services.AddScoped<AccountAccessorService, AccountAccessorServiceImpl>();
builder.Services.AddScoped<PermissionService, PermissionServiceImpl>();

builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();
app.UseStaticFiles();

//Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();