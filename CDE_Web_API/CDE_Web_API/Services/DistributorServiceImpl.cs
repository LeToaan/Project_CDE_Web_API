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

public class DistributorServiceImpl : DistributorService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public DistributorServiceImpl(
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
    public async Task<IActionResult> creater_distriburot(DistributorDTO distributorDTO)
    {

        Distributor distributor = _mapper.Map<Distributor>(distributorDTO);
        try
        {
            Thread thread = Thread.CurrentThread;

            var distributorExit = _dbContext.Distributors.FirstOrDefault(a => a.Email == distributor.Email);
            if (distributorExit != null)
            {
                return new BadRequestObjectResult(new { msg = "Area already exists!" });
            }



            _dbContext.Distributors.Add(distributor);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var area = _dbContext.Areas.FirstOrDefault(a => a.Id == distributor.AreaId);
                Account account = new Account();
                account.Password = "123456";
                account.Fullname = distributor.Name;
                account.Email = distributor.Email;
                account.Phone = distributor.Phone;
                account.Address = area.AreaName;
                account.Status = true;
                account.Created = DateTime.Now;
                account.AreaId = distributor.AreaId;
                account.PositionGroupId = distributor.PositionGroupId;
                _dbContext.Accounts.Add(account);
                await _dbContext.SaveChangesAsync();
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
