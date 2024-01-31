using AutoMapper;
using BCrypt.Net;
using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Web.Http.ModelBinding;

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

    public async Task<IActionResult> resiter(AccountDTO accountDTO)
    {
        var user = _mapper.Map<Account>(accountDTO);
        var modelState = _httpContextAccessor.HttpContext?.Items["MS_ModelState"] as ModelStateDictionary;

        try
        {
            if (modelState != null && !modelState.IsValid)
            {
                var userExit = await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == user.Email);
                if(userExit != null)
                {
                    return new BadRequestObjectResult(new { msg = "User already exists!" });
                }
                user.Email = accountDTO.Email;
                user.Fullname = accountDTO.Fullname;
                user.Password = BCrypt.Net.BCrypt.HashPassword("123456");
                user.PositionGroupId = accountDTO.PositionGroupId;
                user.Superior = accountDTO.Superior;
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

            return new BadRequestObjectResult(new { msg = "" });

        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
        
    }
}
