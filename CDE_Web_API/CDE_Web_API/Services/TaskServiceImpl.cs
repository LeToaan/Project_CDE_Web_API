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

public class TaskServiceImpl : TaskService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public TaskServiceImpl(
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

    public async Task<IActionResult> create_task(TaskDTO taskDTO, int id)
    {
        Models.Task task = _mapper.Map<Models.Task>(taskDTO);
        try
        {

            var visit = await _dbContext.Visits.FirstOrDefaultAsync(p => p.Id == id);
            if (visit == null)
            {
                return new BadRequestObjectResult(new { msg = "Please, choose visit!" });
            }

            var report = await _dbContext.Accounts.FirstOrDefaultAsync(s => s.Id == task.Report);
            var implement = await _dbContext.Accounts.FirstOrDefaultAsync(i => i.Id== task.Implement);
          /*  if(report.PositionGroupId != 2 || implement.PositionGroupId != 2 || report.PositionGroupId == 3 || implement.PositionGroupId == 3)
            {
                return new BadRequestObjectResult(new { msg = "Report and Implement just position sales!" });
            }*/

            task.Status = 1;
            task.VisitId = id;
           
            _dbContext.Tasks.Add(task);
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
}
