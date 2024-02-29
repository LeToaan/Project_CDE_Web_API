using AutoMapper;
using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http.ModelBinding;
using System.Xml.Linq;

namespace CDE_Web_API.Services;

public class AuthAccountServiceImpl : AuthAccountService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;

    public AuthAccountServiceImpl(
        IConfiguration configuration, 
        CDEDbContext dbContext, 
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
        )
    {
       
        _configuration = configuration;
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<IActionResult> register(AccountDTO accountDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Login(AccountLoginDTO accountDTO)
    {
        try
        {
            var modelState = _httpContextAccessor.HttpContext?.Items["MS_ModelState"] as ModelStateDictionary;
                if (modelState != null && !modelState.IsValid)
                {
                    return new BadRequestObjectResult(modelState);
                }
                else
                {
                var user = await _dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Email == accountDTO.Email);

                if(user.Email != accountDTO.Email && user.Password != accountDTO.Password) 
                {
                    return new BadRequestObjectResult(new {msg = "Login Failed!"});
                }else
                {
                    var positionGroup = await _dbContext.PositionGroups.AsNoTracking().FirstOrDefaultAsync(p => p.Id == user.PositionGroupId);
                    string tokent = CreateTokent(user.Email, positionGroup.Name);
                    return new OkObjectResult(tokent);
                }
            }

        }
        catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
    }

    private string CreateTokent(string email, string positionGroup)
    {
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, positionGroup),
        };

        var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));
        var creds = new SigningCredentials(authKey, SecurityAlgorithms.HmacSha512Signature);
        var expiry = DateTime.Now.AddHours(1);

        var tokent = new JwtSecurityToken
            (
                
                claims : claims,
                expires: expiry,
                signingCredentials: creds
            );
        var jwt = new JwtSecurityTokenHandler().WriteToken(tokent);
        return jwt;
    }

    public async Task<IActionResult> getAccount(string email)
    {
        try
        {
            var user = await _dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

            return new OkObjectResult(user);
        }
        catch
        {
            return new BadRequestObjectResult(new { msg = "loiiii" });
        }
    }
}
