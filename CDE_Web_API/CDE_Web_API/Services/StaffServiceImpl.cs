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
using System.Xml.Linq;


namespace CDE_Web_API.Services;

public class StaffServiceImpl : StaffService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;


    public StaffServiceImpl(
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

    public dynamic staff_manager()
    {
        var getLogin =  _dbContext.Accounts.FirstOrDefault(a => a.Email == _authAccountService.getAccount());
        var position_title =  _dbContext.PositionTitles.FirstOrDefault(p => p.Id == getLogin.PositionTitleId);
        dynamic staff = null;

        switch (position_title.Name)
        {
            case "Administrator":
                staff = _dbContext.Accounts.Select(account => new
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
                        position_groupId = position.PositionGroup.Id,
                        position_groupName = position.PositionGroup.Name,
                    }).FirstOrDefault()
                }).ToList();
                break;
            case "VPCD":
                staff = _dbContext.Accounts.Where(s => s.PositionTitleId == 4 ||
                s.PositionTitleId == 5 || s.PositionTitleId == 6 || s.PositionTitleId == 7 ||
                s.PositionTitleId == 8 || s.PositionTitleId == 10)
                    .Select(account => new
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
                            position_groupId = position.PositionGroup.Id,
                            position_groupName = position.PositionGroup.Name,
                        }).FirstOrDefault()
                    }).ToList();
                break;
            case "Chanel Activation Head":
                staff = _dbContext.Accounts.Where(s => s.PositionTitleId == 7)
                    .Select(account => new
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
                            position_groupId = position.PositionGroup.Id,
                            position_groupName = position.PositionGroup.Name,
                        }).FirstOrDefault()
                    }).ToList();
                break;
            case "BM":
                staff = _dbContext.Accounts.Where(s => s.PositionTitleId == 6 ||
                s.PositionTitleId == 8)
                    .Select(account => new
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
                            position_groupId = position.PositionGroup.Id,
                            position_groupName = position.PositionGroup.Name,
                        }).FirstOrDefault()
                    }).ToList();
                break;
            case "BAM" or "ASM": // Đây không phải cách đúng để sử dụng case trong switch, sẽ có lỗi xảy ra
                staff = _dbContext.Accounts.Where(s => s.PositionTitleId == 9)
                    .Select(account => new
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
                            position_groupId = position.PositionGroup.Id,
                            position_groupName = position.PositionGroup.Name,
                        }).FirstOrDefault()
                    }).ToList();
                break;
            case "Sale SUP – Sale Supervisor":
                staff = _dbContext.Accounts.Where(s => s.PositionTitleId == 10)
                    .Select(account => new
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
                            position_groupId = position.PositionGroup.Id,
                            position_groupName = position.PositionGroup.Name,
                        }).FirstOrDefault()
                    }).ToList();
                break;
            default: return null;
        }

        return staff;
    }
}
