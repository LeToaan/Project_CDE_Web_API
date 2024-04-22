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
    [HttpGet("area-manager"), Authorize(Roles = "Administrator, Owner, VPCD")]
    public async Task<dynamic> area_manager()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return areaService.Area_manager(null);
    }
    [Produces("application/json")]
    [HttpGet("area-search/areaKeyword"), Authorize(Roles = "Administrator, Owner, VPCD")]
    public async Task<dynamic> area_search(string? areaKeyword)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return areaService.Area_manager(areaKeyword);
    }

    [Produces("application/json")]
    [HttpGet("area-detail/{idArea}"), Authorize(Roles = "Administrator, Owner, VPCD")]
    public async Task<dynamic> area_Detail(int idArea)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return areaService.Area_detail(idArea, null);
    }

    [Produces("application/json")]
    [HttpGet("area-detail-searchUser/{idArea}/{userKeyword}"), Authorize(Roles = "Administrator, Owner, VPCD")]
    public async Task<dynamic> area_Detail(int idArea, string? userKeyword)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return areaService.Area_detail(idArea, userKeyword);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_area"), Authorize(Roles = "Administrator, Owner, VPCD, Create new area")]
    public async Task<IActionResult> create_area([FromBody] AreaDTO areaDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await areaService.Creater_area(areaDTO);
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update_area/{idArea}"), Authorize(Roles = "Administrator, Owner, VPCD, Update area detail")]
    public async Task<IActionResult> update_area(int idArea, string name)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await areaService.Update_area(idArea, name);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete_area/{idArea}"), Authorize(Roles = "Administrator, Owner, VPCD, Delete areas")]
    public async Task<IActionResult> delete_area(int idArea)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await areaService.Delete_area(idArea);
    }
}
