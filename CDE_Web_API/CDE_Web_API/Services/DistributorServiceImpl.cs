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
            var account_ = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == distributor.Email);
            if (distributorExit != null || account_ != null)
            {
                return new BadRequestObjectResult(new { msg = "Distributor already exists!" });
            }

            Account account = new Account();
            var password = GenaratePassword.CreatePassword(6);
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            account.Password = hashPassword;
            account.Fullname = distributor.Name;
            account.Email = distributor.Email;
            account.Phone = distributor.Phone;
            account.Address = distributor.Address;
            account.Status = distributor.Status;
            account.Created = DateTime.Now;
            account.PositionTitleId = 10;

            _dbContext.Accounts.Add(account);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                
                distributor.AccountId = account.Id;
                _dbContext.Distributors.Add(distributor);
                
                await _dbContext.SaveChangesAsync();
                var mailHelper = new MailHelper(_configuration);
                mailHelper.Send(_configuration["Gmail:Username"], account.Email,
                "Information Your Account", ContenMailHelper.content(password));
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

    public async Task<IActionResult> update_distriburot(DistributorUpdateDTO distributorDTO, int id)
    {

        Distributor distributor = _mapper.Map<Distributor>(distributorDTO);
        try
        {
            var distributor_find = await _dbContext.Distributors.FirstOrDefaultAsync(d => d.Id == id);
            if (distributor_find == null || distributor_find.Account.PositionTitle.Name != "Distributor")
            {
                return new BadRequestObjectResult(new { msg = "Distributor not exists or Invalid!" });
            }else
            {
                var distributorExit = _dbContext.Distributors.FirstOrDefault(a => a.Email == distributor.Email);
                var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == distributor_find.Email);
                if ((distributorExit != null && distributor_find.Email != distributor.Email) || (await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == distributor.Email) != null && distributor_find.Email != distributor.Email))
                {
                    return new BadRequestObjectResult(new { msg = "Distributor already exists or Invalid!" });
                }

                distributor_find.Name = distributor.Name;
                distributor_find.Email = distributor.Email;
                distributor_find.Phone = distributor.Phone;
                distributor_find.SaleManagement = distributor.SaleManagement;
                distributor_find.Sales = distributor.Sales;
                distributor_find.Status = distributor.Status;

                _dbContext.Entry(distributor_find).State = EntityState.Modified;
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    //var area = _dbContext.Areas.FirstOrDefault(a => a.Id == 1);
                    account.Fullname = distributor_find.Name;
                    account.Email = distributor_find.Email;
                    account.Phone = distributor_find.Phone;
                    account.Status = distributor_find.Status;

                    _dbContext.Entry(account).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return new OkObjectResult(new { result = true });
                }
                else
                {
                    return new OkObjectResult(new { result = false });
                }
            }
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }
}
