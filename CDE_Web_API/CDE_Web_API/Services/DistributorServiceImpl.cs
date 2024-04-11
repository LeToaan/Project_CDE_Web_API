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
using System;
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
    public async Task<IActionResult> creater_distriburot(int idArea,DistributorDTO distributorDTO)
    {

        Distributor distributor = new Distributor();
        try
        {
            var areaExist = _dbContext.Areas.FirstOrDefault(a => a.Id == idArea);
            if (areaExist == null)
            {
                return new BadRequestObjectResult(new { msg = "Area not found!" });
            }
            var distributorExit = _dbContext.Distributors.FirstOrDefault(a => a.Email == distributorDTO.Email);
            var account_ = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == distributorDTO.Email);
            if (distributorExit != null || account_ != null)
            {
                return new BadRequestObjectResult(new { msg = "Distributor already exists!" });
            }

            Account account = new Account();
            var password = GenaratePassword.CreatePassword(6);
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            account.Password = hashPassword;
            account.Fullname = distributorDTO.Name;
            account.Email = distributorDTO.Email;
            account.Phone = distributorDTO.Phone;
            account.Address = distributorDTO.Address;
            account.Status = distributorDTO.Status;
            account.Created = DateTime.Now;
            account.PositionTitleId = 10;
            account.AreaId = idArea;

            var salesMangement = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == distributorDTO.SaleManagement);
            if (salesMangement == null)
            {
                return new BadRequestObjectResult(new { msg = "Sale Management not found!" });
            }
            if (salesMangement.PositionTitle.PositionGroup.Name.Equals("System") || salesMangement.PositionTitle.PositionGroup.Name.Equals("VPCD"))
            {
                return new BadRequestObjectResult(new { msg = "Sale Management Invalid!" });
            }

            var sales = "[" + string.Join(", ", distributorDTO.Sales) + "]";
            string numbersStringSales = sales.Replace("[", "").Replace("]", "");

            string[] numberStringsSales = numbersStringSales.Split(',');

            int[] numbersSales = numberStringsSales.Select(s => int.Parse(s.Trim())).ToArray();
            foreach (int number in numbersSales)
            {
                var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                if (user_sale == null)
                {
                    return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                }
                if (!user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor") ||
                    !user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor - OM/TL"))
                {
                    return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " Invalid!" });
                }
            }

            _dbContext.Accounts.Add(account);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                
                distributor.AccountId = account.Id;
                distributor.Name = distributorDTO.Name;
                distributor.Address = distributorDTO.Address;
                distributor.Phone = distributorDTO.Phone;
                distributor.SaleManagement = distributorDTO.SaleManagement;
                distributor.Sales = sales;
                distributor.Status = distributorDTO.Status;
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

        try
        {
            var distributor_find = await _dbContext.Distributors.FirstOrDefaultAsync(d => d.Id == id);
            if (distributor_find == null || !distributor_find.Account.PositionTitle.Name.Equals("Distributor - OM/TL"))
            {
                return new BadRequestObjectResult(new { msg = "Distributor not exists or Invalid!" });
            }else
            {
                var distributorExit = _dbContext.Distributors.FirstOrDefault(a => a.Email == distributorDTO.Email);
                var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == distributor_find.Email);
                if ((distributorExit != null && distributor_find.Email != distributorDTO.Email) || (await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == distributorDTO.Email) != null && distributor_find.Email != distributorDTO.Email))
                {
                    return new BadRequestObjectResult(new { msg = "Distributor already exists or Invalid!" });
                }
                var salesMangement = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == distributorDTO.SaleManagement);
                if (salesMangement == null)
                {
                    return new BadRequestObjectResult(new { msg = "Sale Management not found!" });
                }
                if (salesMangement.PositionTitle.PositionGroup.Name.Equals("System") || salesMangement.PositionTitle.PositionGroup.Name.Equals("VPCD"))
                {
                    return new BadRequestObjectResult(new { msg = "Sale Management Invalid!" });
                }

                var sales = "[" + string.Join(", ", distributorDTO.Sales) + "]";
                string numbersStringSales = sales.Replace("[", "").Replace("]", "");

                string[] numberStringsSales = numbersStringSales.Split(',');

                int[] numbersSales = numberStringsSales.Select(s => int.Parse(s.Trim())).ToArray();
                foreach (int number in numbersSales)
                {
                    var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                    if (user_sale == null)
                    {
                        return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                    }
                    if (!user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor") || 
                        !user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor - OM/TL"))
                    {
                        return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " Invalid!" });
                    }
                }
                distributor_find.Name = distributorDTO.Name;
                distributor_find.Email = distributorDTO.Email;
                distributor_find.Phone = distributorDTO.Phone;
                distributor_find.SaleManagement = distributorDTO.SaleManagement;
                distributor_find.Sales = sales;
                distributor_find.Status = distributorDTO.Status;

                _dbContext.Entry(distributor_find).State = EntityState.Modified;
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    
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

    public async Task<IActionResult> delete_distriburot(int idDistributor)
    {
        try
        {
            var distributor = await _dbContext.Distributors.FindAsync(idDistributor);
            if(distributor == null)
            {
                return new BadRequestObjectResult(new { msg = "Distributor not found!" });
            }
            if (!distributor.Account.PositionTitle.PositionGroup.Name.Equals("Distributor"))
            {
                return new BadRequestObjectResult(new { msg = "Just was delete Distributor!" });
            }

            var accounts = await _dbContext.Accounts.Where(a => a.DistributorId != null).ToListAsync();

            foreach(var acc in accounts)
            {
                if (acc.DistributorId != null)
                {
                    string distributorIdString = acc.DistributorId.Replace("[", "").Replace("]", "");

                    string[] distributorIdStrings = distributorIdString.Split(',');

                    int[] distributorIds = distributorIdStrings.Select(s => int.Parse(s.Trim())).ToArray();

                    int indexRemove = 0;
                    foreach (int distributorId in distributorIds)
                    {
                        if (distributor.Id == distributorId)
                        {
                            distributorIds = distributorIds.Where((val, index) => index != indexRemove).ToArray();
                            var distributorUpdate = "[" + string.Join(", ", distributorIds) + "]";
                            acc.DistributorId = distributorUpdate;
                            _dbContext.Entry(acc).State = EntityState.Modified;
                        }
                        indexRemove++;
                    }
                }
            }

           

            _dbContext.Distributors.Remove(distributor);
            _dbContext.Accounts.Remove(distributor.Account);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
               

                return new OkObjectResult(new { msg = "Delete Success" });
            } else { 
                return new BadRequestObjectResult(new { msg = "Delete Failed!" });}

        }catch(Exception ex)
        {
            return new BadRequestObjectResult(new { ex.Message });
        }
    }
}
