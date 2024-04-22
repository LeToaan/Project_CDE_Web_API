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
using System.Configuration;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using System.Xml.Linq;


namespace CDE_Web_API.Services;

public class PermissionServiceImpl : PermissionService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public PermissionServiceImpl(
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

    public dynamic GetPermission()
    {
        var permission = _dbContext.Permissions.Select(permission => new
        {
            Id = permission.Id,
            Name = permission.Name,
            PermissionModules = _dbContext.PermissionModules.Where(p => p.Id == permission.PermissionMuduleId)
            .Select(module => new
            {
                Name = module.Name,
            }).FirstOrDefault()
        }).ToList();
        return permission;
    }

    public async Task<IActionResult> SetPermission(int id, PermissionAccountDTO permissions)
    {
        
        try
        {
            var user = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (user == null)
            {
                return new BadRequestObjectResult(new { msg = "User not found!" });
            }

            var permission = "[" + string.Join(", ", permissions.PermissionId) + "]";
            string numbersString = permission.Replace("[", "").Replace("]", "");

            // Tách chuỗi thành các chuỗi con dựa trên dấu phẩy
            string[] numberStrings = numbersString.Split(',');

            // Chuyển đổi mỗi chuỗi con thành một số nguyên
            int[] numbers = numberStrings.Select(s => int.Parse(s.Trim())).ToArray();

            // In ra từng giá trị
            foreach (int number in numbers)
            {
                var permission_find = await _dbContext.Permissions.FirstOrDefaultAsync(p => p.Id == number);
                if (permission_find == null)
                {
                    return new BadRequestObjectResult(new { msg = "Permission not exisit!" });
                }
            }


            user.PermissionId = permission;

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new { msg = "Set Permission Success" });
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }
}
