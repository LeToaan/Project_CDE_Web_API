using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDE_Web_API.Controllers;
[Route("api/[controller]"), Authorize]
[ApiController]
public class VisitController : Controller
{
    private VisitService visitService;
    private AuthAccountService authAccountService;

    public VisitController(
        VisitService _visitService,
        AuthAccountService _authAccountService
        )
    {
        visitService = _visitService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [HttpGet("visit")]
    public dynamic Visit()
    {
        return visitService.VisitManager();
    }

    [Produces("application/json")]
    [HttpGet("visit-history")]
    public dynamic VisitHistory()
    {
        return visitService.VitsitHistory();
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_visit"), Authorize(Roles = "Administrator, Owner, Create new visit plan")]
    public async Task<IActionResult> create_visit([FromBody] VisitDTO visitDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await visitService.Create_visit(visitDTO);
    }

    [Produces("application/json")]
    [HttpGet("visit_detail/{id}")]
    public async Task<dynamic> visit_detail(int id)
    {
        return await visitService.VisitDetail(id);
    }
}
