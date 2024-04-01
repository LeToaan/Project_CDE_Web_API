using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private AccountService accountService;
    private AuthAccountService authAccountService;
    private PositionTitleService positionTitleService;
    
    public AccountController(
        AccountService _accountService,
        AuthAccountService _authAccountService,
        PositionTitleService _positionTitleService
        ) { 
        accountService = _accountService;
        authAccountService = _authAccountService;
        positionTitleService = _positionTitleService;
    }

    [Produces("application/json")]
    [HttpGet("getAccountSystem")]
    public ActionResult<dynamic> getAccountSystem()
    {
        
        return Ok(authAccountService.getAccountSystems());
    }

    [Produces("application/json")]
    [HttpGet("getAccountSales")]
    public ActionResult<dynamic> getAccountSales()
    {

        return Ok(authAccountService.getAccountSales());
    }

    [Produces("application/json")]
    [HttpGet("getAccountDistributor")]
    public ActionResult<dynamic> getAccountDistributor()
    {

        return Ok(authAccountService.getAccountDistributor());
    }

    [Produces("application/json")]
    [HttpGet("getAccountGuest")]
    public ActionResult<dynamic> getAccountGuest()
    {

        return Ok(authAccountService.getAccountGuest());
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AccountLoginDTO accountDTO)
    {
        return await authAccountService.Login(accountDTO);
    }

    [Produces("application/json")]
    [HttpGet("getPositionTitleUser")]
    public ActionResult<dynamic> getPositionUser()
    {

        return Ok(positionTitleService.getPosition_Title_user());
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create-user"), Authorize(Roles = "System ,Sales")]
    public async Task<IActionResult> create_user([FromBody] AccountDTO accountDTO)
    {
       
        return await accountService.register(accountDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update-user/{id}"), Authorize(Roles = "System ,Sales")]
    public async Task<IActionResult> update_user([FromBody] AccountDTO accountDTO, int id)
    {
        
        return await accountService.update_user(accountDTO, id);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("delete-user/{id}"), Authorize(Roles = "System ,Sales")]
    public async Task<IActionResult> delete_user(int id)
    {
       
        return await accountService.delete_user(id);
    }

    [Produces("application/json")]
    [HttpGet("getPositionTitleSales")]
    public ActionResult<dynamic> getPositionSales()
    {

        return Ok(positionTitleService.getPosition_Title_Sales());
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create-sales"), Authorize(Roles = "System")]
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
    [HttpPut("update-sales/{id}"), Authorize(Roles = "System")]
    public async Task<IActionResult> update_sales([FromBody] AccountSalesUpdateDTO accountSalesDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.update_sales(accountSalesDTO, id);
    }

    [Produces("application/json")]
    [HttpGet("forget-password/{email}")]
    public async Task<IActionResult> forgetPassword(string email)
    {
        
        return await accountService.forget_password(email);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("reset-password/{code}")]
    public async Task<IActionResult> resetPassword(string code ,[FromBody] ResetPasswordDTO resetPasswordDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.reset_password(code ,resetPasswordDTO);
    }
}
