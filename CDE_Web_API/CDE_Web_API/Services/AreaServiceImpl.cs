using AutoMapper;
using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Helpers;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
    public async Task<IActionResult> Creater_area(AreaDTO areaDTO)
    {
        Area area = _mapper.Map<Area>(areaDTO);
        try
        {            
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

    public async Task<IActionResult> Update_area(int idArea, string name)
    {
        try
        {
            if (!name.IsNullOrEmpty())
            {
                var area = await _dbContext.Areas.FirstOrDefaultAsync(a => a.Id == idArea);
                if (name == area.AreaName)
                {
                    area.AreaName = name;
                   
                }
                else
                {
                    var arearExit = await _dbContext.Areas.FirstOrDefaultAsync(a => a.AreaName == name);
                    if (arearExit != null)
                    {
                        return new BadRequestObjectResult(new { msg = "Area already exists!" });
                    }
                    area.AreaName = name;                    
                }
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
                return new BadRequestObjectResult(new { msg = "Area not emty!" });
            }
         
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }

    public async Task<IActionResult> Delete_area(int idArea)
    {
        try
        {
            var area = await _dbContext.Areas.FindAsync(idArea);
            if (area == null)
            {
                return new BadRequestObjectResult(new { msg = "Area not found!" });
            }

            var staff = await _dbContext.Accounts.FirstOrDefaultAsync(s => s.AreaId == idArea);
            
            if (staff == null)
            {
                _dbContext.Areas.Remove(area);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new OkObjectResult(new { msg = "Delete success!" });
                }
                else { return new BadRequestObjectResult(new { msg = "Delete failed!" }); }
            }
            else
            {
                return new BadRequestObjectResult(new { msg = "Area with code "+ area.AreaCode+" remove because area has user." });
            }

        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(new { msg = e.Message });
        }
    }

    public dynamic Area_detail(int idArea, string? userKeyword)
    {
        var getLogin = _dbContext.Accounts.FirstOrDefault(a => a.Email == _authAccountService.getAccount());
        if (getLogin == null)
        {
            return new BadRequestObjectResult(new { msg = "Please, Login!" });
        }
        dynamic user_area = null;
        if (getLogin.PositionTitle.Name.Equals("Administrator"))
        {
            user_area = _dbContext.Accounts.Where(a => a.AreaId == idArea).Select(account => new
            {
                Staff = _dbContext.Accounts.Where(s => 
                !s.PositionTitle.PositionGroup.Name.Equals("System") &&
                s.PositionTitle.PositionGroup.Name.Equals("Sales") && s.AreaId == idArea
                ).Select(staff => new
                {
                    Id = staff.Id,
                    Fullname = staff.Fullname,
                    Email = staff.Email,
                    Positition = staff.PositionTitle.Name,
                    Status = staff.Status
                }).ToList(),
                Distributor = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Name.Equals("Distributor") && s.AreaId == idArea).Select(distributor => new
                {
                    Id = distributor.Id,
                    Fullname = distributor.Fullname,
                    Email = distributor.Email,
                    Positition = distributor.PositionTitle.Name,
                    Status = distributor.Status
                }).ToList(),
            }).FirstOrDefault();

            if (userKeyword != null)
            {
                if(userKeyword.IsNullOrEmpty())
                {
                    return user_area;
                }else
                {
                    user_area = _dbContext.Accounts.Where(a => a.AreaId == idArea).Select(account => new
                    {
                        Staff = _dbContext.Accounts.Where(s =>
                        !s.PositionTitle.PositionGroup.Name.Equals("System") &&
                        s.PositionTitle.PositionGroup.Name.Equals("Sales") && 
                        (s.Email.Contains(userKeyword) || s.Fullname.Contains(userKeyword))
                        && s.AreaId == idArea
                ).Select(staff => new
                {
                    Id = staff.Id,
                    Fullname = staff.Fullname,
                    Email = staff.Email,
                    Positition = staff.PositionTitle.Name,
                    Status = staff.Status
                }).ToList(),
                        Distributor = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Name.Equals("Distributor") &&
                        (s.Email.Contains(userKeyword) || s.Fullname.Contains(userKeyword))
                        && s.AreaId == idArea).Select(distributor => new
                        {
                            Id = distributor.Id,
                            Fullname = distributor.Fullname,
                            Email = distributor.Email,
                            Positition = distributor.PositionTitle.Name,
                            Status = distributor.Status
                        }).ToList(),
                    }).FirstOrDefault();
                }
            }
        }
        if (getLogin.PositionTitle.Name.Equals("VPCD"))
        {
            user_area = _dbContext.Accounts.Where(a => a.AreaId == idArea).Select(account => new
            {
                Staff = _dbContext.Accounts.Where(s => 
                !s.PositionTitle.PositionGroup.Name.Equals("System") &&
                s.PositionTitle.PositionGroup.Name.Equals("Sales") &&
                !s.PositionTitle.Name.Equals("VPCD") && s.AreaId == idArea).Select(staff => new
                {
                    Id = staff.Id,
                    Fullname = staff.Fullname,
                    Email = staff.Email,
                    Positition = staff.PositionTitle.Name,
                    Status = staff.Status
                }).ToList(),
                Distributor = _dbContext.Accounts.Where(d => d.PositionTitle.PositionGroup.Name.Equals("Distributor") && d.AreaId == idArea).Select(distributor => new
                {
                    Id = distributor.Id,
                    Fullname = distributor.Fullname,
                    Email = distributor.Email,
                    Positition = distributor.PositionTitle.Name,
                    Status = distributor.Status
                }).ToList(),
            }).FirstOrDefault();

            if (userKeyword != null)
            {
                if (userKeyword.IsNullOrEmpty())
                {
                    return user_area;
                }
                else
                {
                    user_area = _dbContext.Accounts.Where(a => a.AreaId == idArea).Select(account => new
                    {
                        Staff = _dbContext.Accounts.Where(s =>
                         !s.PositionTitle.PositionGroup.Name.Equals("System") &&
                        s.PositionTitle.PositionGroup.Name.Equals("Sales") &&
                        !s.PositionTitle.Name.Equals("VPCD") &&
                        (s.Email.Contains(userKeyword) || s.Fullname.Contains(userKeyword) && s.AreaId == idArea)
                ).Select(staff => new
                {
                    Id = staff.Id,
                    Fullname = staff.Fullname,
                    Email = staff.Email,
                    Positition = staff.PositionTitle.Name,
                    Status = staff.Status
                }).ToList(),
                        Distributor = _dbContext.Accounts.Where(s => s.PositionTitle.PositionGroup.Name.Equals("Distributor") &&
                        (s.Email.Contains(userKeyword) || s.Fullname.Contains(userKeyword)) && s.AreaId == idArea).Select(distributor => new
                        {
                            Id = distributor.Id,
                            Fullname = distributor.Fullname,
                            Email = distributor.Email,
                            Positition = distributor.PositionTitle.Name,
                            Status = distributor.Status
                        }).ToList(),
                    }).FirstOrDefault();
                }
            }
        }


        if (user_area == null)
        {
            return null;
        }

        return user_area;
    }

    public async Task<IActionResult> Change_area(int idUser, int idArea)
    {
        try
        {
            var user = _dbContext.Accounts.FirstOrDefault(a => a.Id == idUser);
            if(user == null) {
                return new BadRequestObjectResult(new { msg = "User not found!" });
            }
            if(user.PositionTitle.Name.Equals("BAM") || user.PositionTitle.Name.Equals("ASM") ||
                user.PositionTitle.Name.Equals("CE – Capability Executive") || 
                user.PositionTitle.Name.Equals("Sale SUP – Sale Supervisor") ||
                user.PositionTitle.Name.Equals("Distributor - OM/TL"))
            {
                var area = await _dbContext.Areas.FirstOrDefaultAsync(a => a.Id == idArea);
                if(area == null)
                {
                    return new BadRequestObjectResult(new { msg = "Area not found!" });
                }
                user.AreaId = idArea;
                _dbContext.Entry(user).State = EntityState.Modified;

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new OkObjectResult(new { result = "Change Area Success" });
                }
                else
                {
                    return new OkObjectResult(new { result = false });
                }

            }
            else
            {
                return new BadRequestObjectResult(new { msg = "Just change staff!" });
            }
        }catch(Exception e)
        {
            return new BadRequestObjectResult(new {msg = e.Message});
        }
    }

    public dynamic Area_manager(string? areaSearch)
    {
            var area = _dbContext.Areas.Select(area => new
                    {
                        id = area.Id,
                        areaCode = area.AreaCode,
                        areaName = area.AreaName,
                        distributorQuantity = _dbContext.Accounts.Where(a => a.AreaId == area.Id && a.PositionTitle.Name.Equals("Distributor - OM/TL")).Count(),
                    }).ToList();
        
        if(areaSearch != null)
        {
            if (areaSearch.IsNullOrEmpty())
            {
                return area;
            }else
            {
                area = _dbContext.Areas
                .Where(a => a.AreaName.Contains(areaSearch) || a.AreaCode.Contains(areaSearch))
                .Select(area => new
                {
                    id = area.Id,
                    areaCode = area.AreaCode,
                    areaName = area.AreaName,
                    distributorQuantity = _dbContext.Accounts
                        .Count(a => a.AreaId == area.Id && a.PositionTitle.Name.Contains("Distributor - OM/TL"))
                })
                .ToList();
            }
        }
        return area;
    }
}
