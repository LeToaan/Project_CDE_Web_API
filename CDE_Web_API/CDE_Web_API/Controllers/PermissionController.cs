using Castle.Core.Internal;
using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private PermissionService permissionService;
    private AuthAccountService authAccountService;
    
    public PermissionController(
        PermissionService _permissionService,
        AuthAccountService _authAccountService
        ) { 
        permissionService= _permissionService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [HttpGet("getPermission")]
    public ActionResult<dynamic> getPermission()
    {
        
        return permissionService.getPermission();
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("setPermission/{id}")]
    public async Task<IActionResult> setPermission(int id, [FromBody] PermissionAccountDTO permissions)
    {

        return await permissionService.setPermission(id, permissions);
    }
}
