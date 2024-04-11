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

            Account account = _mapper.Map<Account>(accountDTO);
            var modelState = _httpContextAccessor.HttpContext?.Items["MS_ModelState"] as ModelStateDictionary;
                if (modelState != null && !modelState.IsValid)
                {
                    return new BadRequestObjectResult(modelState);
                }
                else
                {
                Account user =  _dbContext.Accounts.FirstOrDefault(x => x.Email == account.Email);

                if(user != null) 
                {
                    if (BCrypt.Net.BCrypt.Verify(account.Password, user.Password))
                    {
                        
                        var positionTitle = await _dbContext.PositionTitles.AsNoTracking().FirstOrDefaultAsync(p => p.Id == user.PositionTitleId);
                        string tokent;
                        if (user.PermissionId != null)
                        {
                            tokent = CreateTokent(user.Email, positionTitle.Name, user.PermissionId);
                        }else
                        {
                            tokent = CreateTokent(user.Email, positionTitle.Name, null);
                        }
                        
                        return new OkObjectResult(tokent);
                    }else
                    {
                        return new BadRequestObjectResult(new {msg = "Password is correct!"});
                    }
                    
                }
                else
                {
                 return new BadRequestObjectResult(new { msg = "Email or Password is correct!" });
                    
                }
            }

        }
        catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
    }

    private string CreateTokent(string email, string positionGroup, string permission)
    {
           
            
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, positionGroup),
           
        };

        if(permission != null)
        {
            string numbersString = permission.Replace("[", "").Replace("]", "");

            string[] numberStrings = numbersString.Split(',');

            int[] numbers = numberStrings.Select(s => int.Parse(s.Trim())).ToArray();

            foreach (int number in numbers)
                {
                    var permission_find = _dbContext.Permissions.FirstOrDefault(p => p.Id == number);
                    claims.Add(new Claim(ClaimTypes.Role, permission_find.Name));
                }
        }


       

        var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));
        var creds = new SigningCredentials(authKey, SecurityAlgorithms.HmacSha512Signature);
        var expiry = DateTime.Now.AddDays(7);

        var tokent = new JwtSecurityToken
            (
                
                claims : claims,
                expires: expiry,
                signingCredentials: creds
            );
        var jwt = new JwtSecurityTokenHandler().WriteToken(tokent);
        return jwt;
    }

    public string getAccount()
    {
        var result = string.Empty;
        if(_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        return result;
    }

    public dynamic getAccountSystems()
    {
        var systems = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Id == 1).Select(account => new
        {
            id = account.Id,
            fullname = account.Fullname,
            email = account.Email,
            phone = account.Phone,
            status = account.Status,
            positionTitleId = account.PositionTitleId,
            positionTitle = _dbContext.PositionTitles.Where(p => p.Id == account.PositionTitleId).Select(position => new
            {
                id = position.Id,
                name = position.Name,
            }
                ).FirstOrDefault()
        }).ToList();
        return systems;
    }

    public dynamic getAccountSales()
    {
        var sales = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Id == 2).Select(account => new
        {
            id = account.Id,
            fullname = account.Fullname,
            email = account.Email,
            phone = account.Phone,
            status = account.Status,
            positionTitleId = account.PositionTitleId,
            positionTitle = _dbContext.PositionTitles.Where(p => p.Id == account.PositionTitleId).Select(position => new
            {
                id = position.Id,
                name = position.Name,
                positionGroup = new
                {
                    id = position.PositionGroup.Id,
                    name = position.PositionGroup.Name
                }
            }
                ).FirstOrDefault()
        }).ToList();
        return sales;
    }

    public dynamic getAccountDistributor()
    {
        var distributor = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Id == 3).Select(distributor_ => new
        {
            id = distributor_.Id,           
            email = distributor_.Email,
            phone = distributor_.Phone,
            status = distributor_.Status,
           /* saleManagement = _dbContext.Accounts.Where(a => a.Id == distributor_.SaleManagement).Select(account => new
            {
                id = account.Id,
                fullname = account.Fullname,
                email = account.Email,
                phone = account.Phone,
                status = account.Status,
                positionTitle = _dbContext.PositionTitles.Where(p => p.Id == account.PositionTitleId).Select(position => new
                {
                    id = position.Id,
                    name = position.Name,
                }
               ).FirstOrDefault()

            }).FirstOrDefault(),*/

        }).ToList();
        return distributor;
    }

    public dynamic getAccountGuest()
    {
        var guest = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Id == 4).Select(account => new
        {
            id = account.Id,
            fullname = account.Fullname,
            email = account.Email,
            phone = account.Phone,
            status = account.Status,
            positionTitleId = account.PositionTitleId,
            positionTitle = _dbContext.PositionTitles.Where(p => p.Id == account.PositionTitleId).Select(position => new
            {
                id = position.Id,
                name = position.Name,
            }
                ).FirstOrDefault()
        }).ToList();
        return guest;
    }
}
