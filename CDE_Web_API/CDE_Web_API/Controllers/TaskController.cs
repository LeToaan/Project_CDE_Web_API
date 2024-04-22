using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDE_Web_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : Controller
{
    private TaskService taskService;
    private VisitService visitService;
    private AuthAccountService authAccountService;

    public TaskController(
        TaskService _taskService,
        VisitService _visitService,
        AuthAccountService _authAccountService
        )
    {
        taskService = _taskService;
        visitService = _visitService;
        authAccountService = _authAccountService;
    }

    [Produces("application/json")]
    [HttpGet("getVisit")]
    public ActionResult<dynamic> getVisit()
    {

        return Ok(visitService.GetVisit());
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create_task/{id}"), Authorize(Roles = "Administrator, Owner")]
    public async Task<IActionResult> create_task([FromBody] TaskDTO taskDTO, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await taskService.Create_task(taskDTO, id);
    }
}
