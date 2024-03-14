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

    public DistributorController(
        DistributorService _distributorService,
        AuthAccountService _authAccountService
        )
    {
        distributorService = _distributorService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_distributor"), Authorize(Roles = "System,Distributor")]
    public async Task<IActionResult> create_distributor([FromBody] DistributorDTO distributorDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await distributorService.creater_distriburot(distributorDTO);
    }
}
