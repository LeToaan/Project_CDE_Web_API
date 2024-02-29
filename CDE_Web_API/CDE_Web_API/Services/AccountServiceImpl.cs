using AutoMapper;
using BCrypt.Net;
using CDE_Web_API.DTOs;
using CDE_Web_API.Helpers;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CDE_Web_API.Services;

public class AccountServiceImpl : AccountService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;

    public AccountServiceImpl(
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

    public async Task<IActionResult> register(AccountDTO accountDTO)
    {
        Account user = _mapper.Map<Account>(accountDTO);
        try
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("thread: " + thread.Name);
            Console.WriteLine("is thread pool thread" + thread.IsThreadPoolThread);
                var userExit = _dbContext.Accounts.FirstOrDefault(u => u.Email == user.Email);
                if(userExit != null)
                {
                    return new BadRequestObjectResult(new { msg = "User already exists!" });
                }

            user.Password = GenaratePassword.CreatePassword(12);
                user.PositionGroupId = 2;
                user.Superior = 1;
                user.Status = true;
                user.Created = DateTime.Now;
                user.AreaId = 1;
                user.PositionGroupId = 2;

                _dbContext.Accounts.Add(user);
                if(await _dbContext.SaveChangesAsync() > 0)
                {
                    return new OkObjectResult(new { result = true});
                }else
                {
                    return new OkObjectResult(new { result = false});
                }
                
            
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
        
    }

    public Task<IActionResult> SignInAsync(AccountDTO accountDTO)
    {
        throw new NotImplementedException();
    }

}
