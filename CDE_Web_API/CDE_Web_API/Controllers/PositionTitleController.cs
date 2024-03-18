using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionTitleController : ControllerBase
{
    private PositionTitleService positionTitleService;
    private AuthAccountService authAccountService;
    
    public PositionTitleController(
        PositionTitleService _positionTitleService,
        AuthAccountService _authAccountService
        ) { 
        positionTitleService = _positionTitleService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_positionTitle"), Authorize(Roles = "System")]
    public async Task<IActionResult> create_positionTitle([FromBody] PositionTitleDTO positionTitleDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await positionTitleService.create_positionTitle(positionTitleDTO);
    }

}
