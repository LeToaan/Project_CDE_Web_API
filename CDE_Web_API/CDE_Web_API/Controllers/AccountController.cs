using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private AccountService accountService;
    
    public AccountController(
        AccountService _accountService
        ) { 
        accountService = _accountService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("register")]
    public async Task<IActionResult> register([FromBody] AccountDTO accountDTO)
    {
        return await accountService.resiter(accountDTO);
    }
}
