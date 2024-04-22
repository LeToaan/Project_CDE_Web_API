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
    private AuthAccountService authAccountService;
    private PositionTitleService positionTitleService;
    
    public StaffController(
        StaffService _staffService,
        AuthAccountService _authAccountService,
        PositionTitleService _positionTitleService
        ) { 
        staffService = _staffService;
        authAccountService = _authAccountService;
        positionTitleService = _positionTitleService;
    }

    [Produces("application/json")]
    [HttpGet("staff-manager"), Authorize(Roles = "Administrator, VPCD, BM, Chanel Activation Head, ASM, BAM, CE – Capability Executive, Sale SUP – Sale Supervisor")]
    public ActionResult<dynamic> GetStaff()
    {
        
        return Ok(staffService.Staff_manager());
    }

    [Produces("application/json")]
    [HttpGet("getPositionTitleSales")]
    public ActionResult<dynamic> getPositionSales()
    {

        return Ok(positionTitleService.getPosition_Title_Sales());
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create-sales/{idArea}"), Authorize(Roles = "Administrator, Owner, VPCD, Add new users")]
    public async Task<IActionResult> create_sales(int idArea,[FromBody] AccountSalesDTO accountSalesDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await staffService.Creater_sales(idArea ,accountSalesDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update-sales/{id}"), Authorize(Roles = "Administrator, Owner, VPCD, Update user detail")]
    public async Task<IActionResult> update_sales([FromBody] AccountSalesUpdateDTO accountSalesDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await staffService.Update_sales(accountSalesDTO, id);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete-sales/{id}"), Authorize(Roles = "Administrator, Owner, VPCD")]
    public async Task<IActionResult> delete_sales(int id)
    {

        return await staffService.Delete_sales(id);
    }
}
