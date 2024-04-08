using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDE_Web_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AreaController : Controller
{
    private AreaService areaService;
    private AuthAccountService authAccountService;

    public AreaController(
        AreaService _areaService,
        AuthAccountService _authAccountService
        )
    {
        areaService = _areaService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_area"), Authorize(Roles = "Administrator,Sales")]
    public async Task<IActionResult> create_area([FromBody] AreaDTO areaDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await areaService.creater_area(areaDTO);
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update_area/{idArea}"), Authorize(Roles = "Administrator")]
    public async Task<IActionResult> update_area(int idArea, string name)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await areaService.update_area(idArea, name);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete_area/{idArea}"), Authorize(Roles = "Administrator")]
    public async Task<IActionResult> delete_area(int idArea)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await areaService.delete_area(idArea);
    }
}
