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
    
    public AccountController(
        AccountService _accountService,
        AuthAccountService _authAccountService
        ) { 
        accountService = _accountService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("register")]
    public async Task<IActionResult> register([FromBody] AccountDTO accountDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await accountService.register(accountDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AccountLoginDTO accountDTO)
    {
        return await authAccountService.Login(accountDTO);
    }

  
}
