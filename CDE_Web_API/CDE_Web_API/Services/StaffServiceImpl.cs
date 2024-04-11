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
using System.Security.Principal;
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
            case "BAM":
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
            case "ASM":
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

    public async Task<IActionResult> creater_sales(int idArea, AccountSalesDTO accountSalesDTO)
    {
        Account user = new Account();
        try
        {
            var accountLogin = _dbContext.Accounts.FirstOrDefault(a => a.Email == _authAccountService.getAccount());
            var areaExist = _dbContext.Areas.FirstOrDefault(a => a.Id == idArea);
            if (areaExist == null)
            {
                return new BadRequestObjectResult(new { msg = "Area not found!" });
            }else
            {
                user.AreaId = idArea;
            }
            var userExit = _dbContext.Accounts.FirstOrDefault(u => u.Email == accountSalesDTO.Email);
            if (userExit != null)
            {
                return new BadRequestObjectResult(new { msg = "User already exists!" });
            }

            var position = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.Id == accountSalesDTO.PositionTitleId);
            if (!position.PositionGroup.Name.Equals("Sales") || position == null)
            {
                return new BadRequestObjectResult(new { msg = "Just Position Sales!" });
            }

            if (position.Name.Equals("VPCD"))
            {
                if (!accountLogin.PositionTitle.Name.Equals("Administrator"))
                {
                    return new BadRequestObjectResult(new { msg = "You do not have enough access rights!"});
                }
            }

            var inferior = "[" + string.Join(", ", accountSalesDTO.Inferior) + "]";
            string numbersString = inferior.Replace("[", "").Replace("]", "");

            string[] numberStrings = numbersString.Split(',');

            int[] numbers = numberStrings.Select(s => int.Parse(s.Trim())).ToArray();
            var superior = await _dbContext.Accounts.FirstOrDefaultAsync(s => s.Id == accountSalesDTO.Superior);
            if (superior == null)
            {
                return new BadRequestObjectResult(new { msg = "Superior not found!" });
            }
            switch (position.Name)
            {
                case "VPCD":
                    if (!superior.PositionTitle.Name.Equals("Administrator"))
                    {
                        return new BadRequestObjectResult(new { msg = "Superior was position bigger!" });
                    }
                    else
                    {
                        user.SuperiorId = accountLogin.Id;
                    }
                    foreach (int number in numbers)
                    {
                        var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                        if (user_sale == null)
                        {
                            return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                        }
                        if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                        {
                            return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale or Invalid!" });
                        }
                    }
                    break;
                    case "BM":
                        if (!superior.PositionTitle.Name.Equals("VPCD"))
                        {
                            return new BadRequestObjectResult(new { msg = "Superior was position bigger!" });
                        }
                        else
                        {
                            user.SuperiorId = accountSalesDTO.Superior;
                        }
                    foreach (int number in numbers)
                        {
                            var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                            if (user_sale == null)
                            {
                                return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                            }
                            if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.Name.Equals("BM") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                            {
                                return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale!" });
                            }
                        }
                        break;
                case "ASM":
                    if (!superior.PositionTitle.Name.Equals("BM"))
                    {
                        return new BadRequestObjectResult(new { msg = "Superior was position bigger!" });
                    }
                    else
                    {
                        user.SuperiorId = accountSalesDTO.Superior;
                    }
                    foreach (int number in numbers)
                    {
                        var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                        if (user_sale == null)
                        {
                            return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                        }
                        if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.Name.Equals("BM") || user_sale.PositionTitle.Name.Equals("ASM") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                        {
                            return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale!" });
                        }
                    }
                    break;
                case "Sale SUP – Sale Supervisor":
                    if (!superior.PositionTitle.Name.Equals("ASM") || !superior.PositionTitle.Name.Equals("Sale SUP – Sale Supervisor"))
                    {
                        return new BadRequestObjectResult(new { msg = "Superior was position bigger or Invalid!" });
                    }
                    else
                    {
                        user.SuperiorId = accountSalesDTO.Superior;
                    }
                    foreach (int number in numbers)
                    {
                        var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                        if (user_sale == null)
                        {
                            return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                        }
                        if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.Name.Equals("BM") || user_sale.PositionTitle.Name.Equals("ASM") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                        {
                            return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale or invalid!" });
                        }
                    }
                    break;
                default: break;
            }


            user.Fullname = accountSalesDTO.Fullname;
            user.Email = accountSalesDTO.Email;
            user.PositionTitleId = accountSalesDTO.PositionTitleId;
            user.Inferior = inferior;
            user.Status = accountSalesDTO.Status;
            var password = GenaratePassword.CreatePassword(6);
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            user.Password = hashPassword;
            user.Created = DateTime.Now;
            _dbContext.Accounts.Add(user);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var mailHelper = new MailHelper(_configuration);
                mailHelper.Send(_configuration["Gmail:Username"], user.Email,
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

    public async Task<IActionResult> update_sales(AccountSalesUpdateDTO accountSalesDTO, int id)
    {
        try
        {
            var accountLogin = _dbContext.Accounts.FirstOrDefault(a => a.Email == _authAccountService.getAccount());
            var user_ = _dbContext.Accounts.FirstOrDefault(u => u.Id == id);
            if (user_ != null && user_.PositionTitle.PositionGroup.Name.Equals("Sales"))
            {
                if (accountSalesDTO.Email == user_.Email)
                {
                    user_.Email = accountSalesDTO.Email;
                }
                else
                {
                    var email_exists = await _dbContext.Accounts.FirstOrDefaultAsync(e => e.Email == accountSalesDTO.Email);
                    if (email_exists != null)
                    {
                        return new BadRequestObjectResult(new { msg = "Email realdy exists!" });
                    }
                }

                var position = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.Id == accountSalesDTO.PositionTitleId);
                if (!position.PositionGroup.Name.Equals("Sales") || position == null)
                {
                    return new BadRequestObjectResult(new { msg = "Just Position Sales!" });
                }

                if (position.Name.Equals("VPCD"))
                {
                    if (!accountLogin.PositionTitle.Name.Equals("Administrator"))
                    {
                        return new BadRequestObjectResult(new { msg = "You do not have enough access rights!" });
                    }
                }

                var inferior = "[" + string.Join(", ", accountSalesDTO.Inferior) + "]";
                string numbersStringInferior = inferior.Replace("[", "").Replace("]", "");

                string[] numberStringsInferior = numbersStringInferior.Split(',');

                int[] numbersInferior = numberStringsInferior.Select(s => int.Parse(s.Trim())).ToArray();
                var superior = await _dbContext.Accounts.FirstOrDefaultAsync(s => s.Id == accountSalesDTO.Superior);
                if (superior == null)
                {
                    return new BadRequestObjectResult(new { msg = "Superior not found!" });
                }
                switch (position.Name)
                {
                    case "VPCD":
                        if (!superior.PositionTitle.Name.Equals("Administrator"))
                        {
                            return new BadRequestObjectResult(new { msg = "Superior was position bigger!" });
                        }
                        else
                        {
                            user_.SuperiorId = accountLogin.Id;
                        }
                        foreach (int number in numbersInferior)
                        {
                            var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                            if (user_sale == null)
                            {
                                return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                            }
                            if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                            {
                                return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale or Invalid!" });
                            }
                        }
                        break;
                    case "BM":
                        if (!superior.PositionTitle.Name.Equals("VPCD"))
                        {
                            return new BadRequestObjectResult(new { msg = "Superior was position bigger!" });
                        }
                        else
                        {
                            user_.SuperiorId = accountSalesDTO.Superior;
                        }
                        foreach (int number in numbersInferior)
                        {
                            var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                            if (user_sale == null)
                            {
                                return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                            }
                            if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.Name.Equals("BM") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                            {
                                return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale!" });
                            }
                        }
                        break;
                    case "ASM":
                        if (!superior.PositionTitle.Name.Equals("BM"))
                        {
                            return new BadRequestObjectResult(new { msg = "Superior was position bigger!" });
                        }
                        else
                        {
                            user_.SuperiorId = accountSalesDTO.Superior;
                        }
                        foreach (int number in numbersInferior)
                        {
                            var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                            if (user_sale == null)
                            {
                                return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                            }
                            if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.Name.Equals("BM") || user_sale.PositionTitle.Name.Equals("ASM") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                            {
                                return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale!" });
                            }
                        }
                        break;
                    case "Sale SUP – Sale Supervisor":
                        if (!superior.PositionTitle.Name.Equals("ASM") || !superior.PositionTitle.Name.Equals("Sale SUP – Sale Supervisor"))
                        {
                            return new BadRequestObjectResult(new { msg = "Superior was position bigger or Invalid!" });
                        }
                        else
                        {
                            user_.SuperiorId = accountSalesDTO.Superior;
                        }
                        foreach (int number in numbersInferior)
                        {
                            var user_sale = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == number);
                            if (user_sale == null)
                            {
                                return new BadRequestObjectResult(new { msg = "User " + user_sale.Id + " not exisit!" });
                            }
                            if (user_sale.PositionTitle.Name.Equals("VPCD") || user_sale.PositionTitle.Name.Equals("Administrator") || user_sale.PositionTitle.Name.Equals("BM") || user_sale.PositionTitle.Name.Equals("ASM") || user_sale.PositionTitle.PositionGroup.Name.Equals("Distributor"))
                            {
                                return new BadRequestObjectResult(new { msg = "Position user " + user_sale.Id + " bigger than sale or invalid!" });
                            }
                        }
                        break;
                    default: break;
                }

                var distributor = "[" + string.Join(", ", accountSalesDTO.DistributorId) + "]";
                string numbersString = distributor.Replace("[", "").Replace("]", "");

                string[] numberStrings = numbersString.Split(',');

                int[] numbers = numberStrings.Select(s => int.Parse(s.Trim())).ToArray();

                foreach (int number in numbers)
                {
                    var distributor_find = await _dbContext.Distributors.FirstOrDefaultAsync(p => p.Id == number);
                    if (distributor_find == null)
                    {
                        return new BadRequestObjectResult(new { msg = "Distributor not exisit!" });
                    }
                }

                user_.Inferior = inferior;
                user_.Fullname = accountSalesDTO.Fullname;
                user_.Email = accountSalesDTO.Email;
                user_.Status = accountSalesDTO.Status;
                user_.DistributorId = distributor;
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
            else
            {
                return new BadRequestObjectResult(new { msg = "User not exist!" });
            }

        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }

    public async Task<IActionResult> delete_sales(int id)
    {
        try
        {
            var id_user = await _dbContext.Accounts.FindAsync(id);
            if (id_user == null)
            {
                return new BadRequestObjectResult(new { msg = "User not found!" });
            }
            if (id_user.PositionTitle.PositionGroup.Name.Equals("Sales"))
            {
                _dbContext.Accounts.Remove(id_user);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new OkObjectResult(new { msg = "Delete success!" });
                }
                else { return new BadRequestObjectResult(new { msg = "Delete failed!" }); }
            }
            else
            {
                return new BadRequestObjectResult(new { msg = "Just was delete sales!" });
            }

        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(new { msg = e.Message });
        }
    }
}
