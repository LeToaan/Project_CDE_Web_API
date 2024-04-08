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
    private StaffService staffService;
    private AccountService accountService;
    private AuthAccountService authAccountService;
    private PositionTitleService positionTitleService;
    
    public StaffController(
        StaffService _staffService,
        AccountService _accountService,
        AuthAccountService _authAccountService,
        PositionTitleService _positionTitleService
        ) { 
        staffService = _staffService;
        accountService = _accountService;
        authAccountService = _authAccountService;
        positionTitleService = _positionTitleService;
    }

    [Produces("application/json")]
    [HttpGet("staff-manager"), Authorize(Roles = "Administrator, VPCD, BM, Chanel Activation Head, ASM, BAM, CE – Capability Executive, Sale SUP – Sale Supervisor")]
    public ActionResult<dynamic> GetStaff()
    {
        
        return Ok(staffService.staff_manager());
    }

    [Produces("application/json")]
    [HttpGet("getPositionTitleSales")]
    public ActionResult<dynamic> getPositionSales()
    {

        return Ok(positionTitleService.getPosition_Title_Sales());
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create-sales"), Authorize(Roles = "Administrator")]
    public async Task<IActionResult> create_sales([FromBody] AccountSalesDTO accountSalesDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.creater_sales(accountSalesDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update-sales/{id}"), Authorize(Roles = "Administrator")]
    public async Task<IActionResult> update_sales([FromBody] AccountSalesUpdateDTO accountSalesDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.update_sales(accountSalesDTO, id);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete-sales/{id}"), Authorize(Roles = "Administrator")]
    public async Task<IActionResult> delete_sales(int id)
    {

        return await accountService.delete_sales(id);
    }
}
