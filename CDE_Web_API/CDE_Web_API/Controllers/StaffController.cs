using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private StaffService accountService;
    private AuthAccountService authAccountService;
    private PositionTitleService positionTitleService;
    
    public StaffController(
        StaffService _accountService,
        AuthAccountService _authAccountService,
        PositionTitleService _positionTitleService
        ) { 
        accountService = _accountService;
        authAccountService = _authAccountService;
        positionTitleService = _positionTitleService;
    }

    [Produces("application/json")]
    [HttpGet("staff-manager"), Authorize(Roles = "Administrator, VPCD, BM, Chanel Activation Head, ASM, BAM, CE – Capability Executive, Sale SUP – Sale Supervisor")]
    public ActionResult<dynamic> GetStaff()
    {
        
        return Ok( accountService.staff_manager());
    }
}
