using AutoMapper;
using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Helpers;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http.ModelBinding;
using System.Xml.Linq;


namespace CDE_Web_API.Services;

public class AccountServiceImpl : AccountService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public AccountServiceImpl(
        IConfiguration configuration, 
        CDEDbContext dbContext, 
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        AuthAccountService authAccountService
        )
    {
       
        _configuration = configuration;
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _authAccountService = authAccountService;
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

            user.Password = "0123456";
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


    public async Task<IActionResult> update_user(AccountDTO accountDTO)
    {
        Account user = _mapper.Map<Account>(accountDTO);
         try
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("thread: " + thread.Name);
            Console.WriteLine("is thread pool thread" + thread.IsThreadPoolThread);
            var email = _authAccountService.getAccount();
                var account = _dbContext.Accounts.FirstOrDefault(u => u.Email == email);
            var user_ = _dbContext.Accounts.FirstOrDefault(u => u.Email == user.Email);
            if (account != null )
                {
                
                    user_.Fullname = user.Fullname;
                    user_.Email = user.Email;
                    user_.PositionGroupId = user.PositionGroupId;
                    user_.Status = user.Status;
                }
                _dbContext.Entry(user_).State = EntityState.Modified;
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult(new { msg = true });
            }
            else
            {
                return new BadRequestObjectResult(new { msg = false });
            }
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }

    public async Task<IActionResult> creater_sales(AccountSalesDTO accountSalesDTO)
    {
        Account user = _mapper.Map<Account>(accountSalesDTO);
        try
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("thread: " + thread.Name);
            Console.WriteLine("is thread pool thread" + thread.IsThreadPoolThread);
            var userExit = _dbContext.Accounts.FirstOrDefault(u => u.Email == user.Email);
            if (userExit != null)
            {
                return new BadRequestObjectResult(new { msg = "User already exists!" });
            }

            user.Password = "0123456";
            user.Created = DateTime.Now;
            user.AreaId = 1;

            _dbContext.Accounts.Add(user);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult(new { result = true });
            }
            else
            {
                return new OkObjectResult(new { result = false });
            }


        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }
}
