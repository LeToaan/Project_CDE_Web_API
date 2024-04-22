using CDE_Web_API.DTOs;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDE_Web_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DistributorController : Controller
{
    private DistributorService distributorService;
    private AuthAccountService authAccountService;
    private PositionTitleService positionTitleService;

    public DistributorController(
        DistributorService _distributorService,
        AuthAccountService _authAccountService,
        PositionTitleService _positionTitleService
        )
    {
        distributorService = _distributorService;
        authAccountService = _authAccountService;
        positionTitleService= _positionTitleService;
    }

    /*[Produces("application/json")]
    [HttpGet("getPositionTitleDistributor")]
    public ActionResult<dynamic> getPositionDistributor()
    {

        return Ok(positionTitleService.getPosition_Title_Distributor());
    }*/

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_distributor/{idArea}"), Authorize(Roles = "Administrator, Owner, Create new distributor")]
    public async Task<IActionResult> create_distributor(int idArea, [FromBody] DistributorDTO distributorDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await distributorService.Creater_distriburot(idArea, distributorDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update_distributor/{id}"), Authorize(Roles = "Administrator, Owner, Update detail distributor")]
    public async Task<IActionResult> update_distributor([FromBody] DistributorUpdateDTO distributorDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await distributorService.Update_distriburot(distributorDTO, id);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete_distributor/{idDistributor}"), Authorize(Roles = "Administrator, Owner, Update detail distributor")]
    public async Task<IActionResult> delete_distributor(int idDistributor)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await distributorService.Delete_distriburot(idDistributor);
    }
}
