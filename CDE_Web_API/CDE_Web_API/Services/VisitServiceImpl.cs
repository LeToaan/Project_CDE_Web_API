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

public class VisitServiceImpl : VisitService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public VisitServiceImpl(
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

    public async Task<IActionResult> create_visit(VisitDTO visitDTO)
    {
        Visit visit = _mapper.Map<Visit>(visitDTO);
        try
        {
            var email = _authAccountService.getAccount();
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Email == email);
            var distributor = await _dbContext.Distributors.FirstOrDefaultAsync(p => p.Id == visit.DistributorId);
            if (!distributor.Account.PositionTitle.Name.Equals("Distributor - OM/TL") || distributor == null)
            {
                return new BadRequestObjectResult(new { msg = "Please, choose Distributor!" });
            }
         
            visit.Status = 1;
            visit.Creator = account.Id;
            _dbContext.Visits.Add(visit);
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

    public dynamic getVisit()
    {
        var visit = _dbContext.Visits.Select( visit => new
        {
            id = visit.Id,
            time = visit.Time == 1 ? "Morning" : visit.Time == 2 ? "Afternoon" : "All day",
            datetime = visit.DateTime,
            intent = visit.Intent,
            creator =  _dbContext.Accounts.Where(a => a.Id == visit.Creator).Select( account => new
            {
                account.Id,
                account.Fullname,
                account.Email,
                position =  _dbContext.PositionTitles.Where(p => p.Id == account.PositionTitleId).Select( title => new {
                    title = title.Name,
                    group =  _dbContext.PositionGroups.Where(g => g.Id == title.PositionGroupId).Select(group => new
                    {
                        group.Id,
                        group.Name
                    }).FirstOrDefault(),
                }).FirstOrDefault(),
            }).FirstOrDefault(),
            task = _dbContext.Tasks.Where(t => t.VisitId == visit.Id).Select(task => new
            {
                id = task.Id,
                title = task.Title,
                description = task.Description,
                status = task.Status,
                dateStart = task.DateStart,
                dateEnd = task.DateEnd,
                report = _dbContext.Accounts.Where(a => a.Id == task.Report).Select(accpunt => new
                {
                    id = accpunt.Id,
                    fullname = accpunt.Fullname,
                    email = accpunt.Email,
                    phone = accpunt.Phone
                }).FirstOrDefault(),
                implement = _dbContext.Accounts.Where(a => a.Id == task.Implement).Select(accpunt => new
                {
                    id = accpunt.Id,
                    fullname = accpunt.Fullname,
                    email = accpunt.Email,
                    phone = accpunt.Phone
                }).FirstOrDefault(),
            }).ToList(),
        }).ToList();
        return visit;
    }

    public async Task<dynamic> visitDetail(int id)
    {
        if(await _dbContext.Visits.FindAsync(id) == null)
        {
            return new BadRequestObjectResult(new { msg = "Visit not exists!" });
        }else
        {
            var visit = _dbContext.Visits.Where(v => v.Id == id).Select( visit => new
            {
                id = visit.Id,
                time = visit.Time == 1 ? "Morning" : visit.Time == 2 ? "Afternoon" : "All day",
                datetime = visit.DateTime,
                intent = visit.Intent,
                creator = _dbContext.Accounts.Where(a => a.Id == visit.Creator).Select(account => new
                {
                    account.Id,
                    account.Fullname,
                    account.Email,
                    position = _dbContext.PositionTitles.Where(p => p.Id == account.PositionTitleId).Select(title => new {
                        title = title.Name,
                        group = _dbContext.PositionGroups.Where(g => g.Id == title.PositionGroupId).Select(group => new
                        {
                            group.Id,
                            group.Name
                        }).FirstOrDefault(),
                    }).FirstOrDefault(),
                }).FirstOrDefault(),
                guest = visit.Guest == null ? null : _dbContext.Accounts.Where(g => g.Id == visit.Guest).Select(guest => new
                {
                    guest.Id,
                    guest.Fullname,
                    guest.Email,
                    guest.Phone
                }).FirstOrDefault(),
                task = _dbContext.Tasks.Where(t => t.VisitId == visit.Id).Select(task => new
                {
                    id = task.Id,
                    title = task.Title,
                    description = task.Description,
                    status = task.Status,
                    dateStart = task.DateStart,
                    dateEnd = task.DateEnd,
                    report = _dbContext.Accounts.Where(a => a.Id == task.Report).Select(accpunt => new
                    {
                        id = accpunt.Id,
                        fullname = accpunt.Fullname,
                        email = accpunt.Email,
                        phone = accpunt.Phone
                    }).FirstOrDefault(),
                    implement = _dbContext.Accounts.Where(a => a.Id == task.Implement).Select(accpunt => new
                    {
                        id = accpunt.Id,
                        fullname = accpunt.Fullname,
                        email = accpunt.Email,
                        phone = accpunt.Phone
                    }).FirstOrDefault(),
                }).ToList(),
            }).FirstOrDefault();
            return visit;
        }
        
    }

    public Task<dynamic> searchVisit(string? keyword)
    {
        dynamic vistit_List = _dbContext.Tasks.Where(v => v.Title.Contains(keyword) ||
        v.Visit.Intent.Contains(keyword)
        ).Select(visit => new
        {

        });
        if (keyword == null) {  
            if(keyword == string.Empty)
            {
                return vistit_List;
            }
        }
        return vistit_List;
    }
}
