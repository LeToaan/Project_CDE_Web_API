﻿using AutoMapper;
using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CDE_Web_API.Services;

public class AreaServiceImpl : AreaService
{

    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public AreaServiceImpl(
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
    public async Task<IActionResult> creater_area(AreaDTO areaDTO)
    {
        Area area = _mapper.Map<Area>(areaDTO);
        try
        {
            Thread thread = Thread.CurrentThread;
            
            var arearExit = await _dbContext.Areas.FirstOrDefaultAsync(a => a.AreaName == area.AreaName || a.AreaCode == area.AreaCode);
            if (arearExit != null)
            {
                return new BadRequestObjectResult(new { msg = "Area already exists!" });
            }

            _dbContext.Areas.Add(area);
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

    public async Task<IActionResult> update_area(int idArea, string name)
    {
        try
        {
            if (!name.IsNullOrEmpty())
            {
                var area = await _dbContext.Areas.FirstOrDefaultAsync(a => a.Id == idArea);
                if (name == area.AreaName)
                {
                    _dbContext.Entry(area).State = EntityState.Modified;
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new OkObjectResult(new { result = "Update Success" });
                    }
                    else
                    {
                        return new OkObjectResult(new { result = false });
                    }
                }
                else
                {
                    var arearExit = await _dbContext.Areas.FirstOrDefaultAsync(a => a.AreaName == name);
                    if (arearExit != null)
                    {
                        return new BadRequestObjectResult(new { msg = "Area already exists!" });
                    }

                    _dbContext.Areas.Add(area);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new OkObjectResult(new { result = true });
                    }
                    else
                    {
                        return new OkObjectResult(new { result = false });
                    }
                }
            }else
            {
                return new BadRequestObjectResult(new { msg = "Area not emty!" });
            }
         
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }
}
