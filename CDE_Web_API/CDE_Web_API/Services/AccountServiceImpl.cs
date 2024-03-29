﻿using AutoMapper;
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

                var position_title = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.Id == user.PositionTitleId);
            if(position_title.PositionGroupId != 4) 
            {
                return new BadRequestObjectResult(new { msg = "Just Position Guest!!" });
            }
            else
            {
                user.PositionGroupId = 4;
            }
                var password = GenaratePassword.CreatePassword(6);
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
                user.Password = hashPassword;
                user.Status = true;
                user.Created = DateTime.Now;

                
                 _dbContext.Accounts.Add(user);
                if(await _dbContext.SaveChangesAsync() > 0)
                {
                    var tokentVerify = new Tokent();
                    tokentVerify.VerificationToken = ContenMailHelper.CreateRandomToken();
                    tokentVerify.VerifiedAt = DateTime.Now;
                    _dbContext.Tokents.Add(tokentVerify);
                        if(await _dbContext.SaveChangesAsync() > 0)
                    {
                    user.TokentId = tokentVerify.Id;
                    _dbContext.Entry(user).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    }
                    var mailHelper = new MailHelper(_configuration);
                    mailHelper.Send(_configuration["Gmail:Username"], user.Email,
                    "Information Your Account", ContenMailHelper.content(password));
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


    public async Task<IActionResult> update_user(AccountDTO accountDTO, int id)
    {
        Account user = _mapper.Map<Account>(accountDTO);
         try
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("thread: " + thread.Name);
            Console.WriteLine("is thread pool thread" + thread.IsThreadPoolThread);
            var email = _authAccountService.getAccount();
                var user_ = _dbContext.Accounts.FirstOrDefault(u => u.Id == id);
            if (user != null )
            {
                var position_title = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.Id == user.PositionTitleId);
                if (position_title.PositionGroupId != 4)
                {
                    return new BadRequestObjectResult(new { msg = "Just Position Guest!!" });
                }
                else
                {
                    user_.PositionGroupId = 4;
                }
                    user_.PositionTitleId = user.PositionTitleId;
                    user_.Fullname = user.Fullname;
                    user_.Email = user.Email;
                    user_.Status = user.Status;
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

            var position = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.Id == user.PositionTitleId);
            if (position.PositionGroupId != 2)
            {
                return new BadRequestObjectResult(new { msg = "Just Position Sales!" });
            }else
            {
                user.PositionGroupId = position.PositionGroupId;

            }
            var password = GenaratePassword.CreatePassword(6);
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            user.Password = hashPassword;
            user.Created = DateTime.Now;
            _dbContext.Accounts.Add(user);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var tokentVerify = new Tokent();
                tokentVerify.VerificationToken = ContenMailHelper.CreateRandomToken();
                tokentVerify.VerifiedAt = DateTime.Now;
                _dbContext.Tokents.Add(tokentVerify);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    user.TokentId = tokentVerify.Id;
                    _dbContext.Entry(user).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
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
        Account user = _mapper.Map<Account>(accountSalesDTO);
        try
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("thread: " + thread.Name);
            Console.WriteLine("is thread pool thread" + thread.IsThreadPoolThread);
            var email = _authAccountService.getAccount();
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Email == email);
            var user_ = _dbContext.Accounts.FirstOrDefault(u => u.Id == id);
            if (user_ != null && user_.PositionGroupId == 2)
            {
                if (account.PositionGroupId == 1)
                {
                    var position = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.Id == user.PositionTitleId);
                    var distributor = await _dbContext.Accounts.FirstOrDefaultAsync(d => d.Id == user.Id);
                    if (position.PositionGroupId != 2 && distributor.PositionGroupId != 3)
                    {
                        return new BadRequestObjectResult(new { msg = "Just Position Sales!" });
                    }
                    else
                    {
                        user_.PositionTitleId = user.PositionTitleId;
                        user_.DistributorId = user.DistributorId;
                    }
                    user_.Fullname = user.Fullname;
                    user_.Email = user.Email;
                    user_.Status = user.Status;
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
                    return new BadRequestObjectResult(new { msg = "You are not qualified!" });
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

    public async Task<IActionResult> forget_password(string email)
    {
        var user = await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == email);
        if(user == null)
        {
            return new BadRequestObjectResult(new { msg = "User not found!" });
        }else
        {
                var tokent = await _dbContext.Tokents.FirstOrDefaultAsync(t => t.Id == user.TokentId);
                tokent.PasswordResetToken = GenaratePassword.CreatePassword(6);
                tokent.ResetTokenExpires = DateTime.Now.AddMinutes(30);
                _dbContext.Entry(tokent).State = EntityState.Modified;
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var mailHelper = new MailHelper(_configuration);
                mailHelper.Send(_configuration["Gmail:Username"], user.Email,
                "Code Reset Password", ContenMailHelper.content(tokent.PasswordResetToken));
                return new OkObjectResult(new { msg = "Check your mail to take code!" });
            }else
            {
                return new BadRequestObjectResult(new { msg = "Failed!!" });
            }
                
                
        }
    }

    

    

    public async Task<IActionResult> reset_password(string code,ResetPasswordDTO resetPasswordDTO)
    {
        try
        {
            var tokent = await _dbContext.Tokents.FirstOrDefaultAsync(t => t.PasswordResetToken == code);
            var user = await _dbContext.Accounts.FirstOrDefaultAsync(u => u.TokentId == tokent.Id);
            if (tokent == null || tokent.ResetTokenExpires < DateTime.Now)
            {
                return new BadRequestObjectResult(new { msg = "Code Invalid or Expired!" });
            }


            var hashPassword = BCrypt.Net.BCrypt.HashPassword(resetPasswordDTO.Password);
            user.Password = hashPassword;
            _dbContext.Entry(user).State = EntityState.Modified;
            tokent.PasswordResetToken = null;
            tokent.ResetTokenExpires = null;
            _dbContext.Entry(user).State = EntityState.Modified;
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult(new { msg = "Reset password success!" });
            }else
            {
                return new BadRequestObjectResult(new { msg = "Reset password failed!!" });
            }
        }catch (Exception e)
        {
            return new BadRequestObjectResult(new { msg = e.Message });
        }
        
    }
}
