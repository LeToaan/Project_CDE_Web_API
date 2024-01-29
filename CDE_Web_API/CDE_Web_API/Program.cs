using CDE_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<CDEDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
var app = builder.Build();
app.UseStaticFiles();
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

app.UseRouting();
/*app.UseAuthorization();
*/app.UseEndpoints(_ => { });
app.MapControllers();

app.Run();