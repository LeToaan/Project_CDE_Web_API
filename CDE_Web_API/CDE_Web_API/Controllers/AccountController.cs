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
    [Consumes("application/json")]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AccountLoginDTO accountDTO)
    {
        return await authAccountService.Login(accountDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_user"), Authorize(Roles = "System ,Sales")]
    public async Task<IActionResult> create_user([FromBody] AccountDTO accountDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.register(accountDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update_user/{id}"), Authorize(Roles = "System ,Sales")]
    public async Task<IActionResult> update_user([FromBody] AccountDTO accountDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.update_user(accountDTO, id);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_sales"), Authorize(Roles = "System")]
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
    [HttpPut("update_sales/{id}"), Authorize(Roles = "System ,Sales")]
    public async Task<IActionResult> update_sales([FromBody] AccountSalesUpdateDTO accountSalesDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.update_sales(accountSalesDTO, id);
    }
}
