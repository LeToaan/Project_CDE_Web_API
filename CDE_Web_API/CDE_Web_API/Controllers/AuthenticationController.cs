using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace CDE_Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
   
    private readonly IConfiguration _configuration;
    private AuthAccountService _authAccountService;

    public AuthenticationController(
        AuthAccountService authAccountService,
        IConfiguration configuration)
    {
        _authAccountService= authAccountService;
        _configuration = configuration;
    }

    [Produces("application/json")]
    [HttpGet("getAccount"), Authorize(Roles = "System")]
    public async Task<IActionResult> getaccount()
    {
        return Ok("okokokok");
    }


}
