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

public class PositionTitleServiceImpl : PositionTitleService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;

    public PositionTitleServiceImpl(
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

    public async Task<IActionResult> create_positionTitle(PositionTitleDTO PositionTitleDTO)
    {
        PositionTitle position_title = _mapper.Map<PositionTitle>(PositionTitleDTO);
        try
        {
                var userExit = _dbContext.PositionTitles.FirstOrDefault(p => p.Name == position_title.Name);
                if(userExit != null)
                {
                    return new BadRequestObjectResult(new { msg = "Position Title already exists!" });
                }

               position_title.created = DateTime.Now;

                _dbContext.PositionTitles.Add(position_title);
                if(await _dbContext.SaveChangesAsync() > 0)
                {
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

    public async Task<IActionResult> getPosition_Title_user()
    {
        var position = await _dbContext.PositionTitles.FirstOrDefaultAsync(p => p.PositionGroupId == 4);
        return new OkObjectResult(position);
    }
}
