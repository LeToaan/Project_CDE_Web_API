using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using CDE_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDE_Web_API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
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

    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    [HttpPut("upload-files-task/{idTask}")]
    public async Task<IActionResult> UploadFilesTask(int idTask, List<IFormFile> filesReporter, List<IFormFile> filesImplement)
    {
        return await taskService.Uploads_files(idTask, filesReporter, filesImplement);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("comment-task/{idTask}")]
    public async Task<IActionResult> comment_task(int idTask,[FromBody] RateDTO rateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return await taskService.CommentTask(idTask, rateDTO);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("close-task/{idTask}")]
    public async Task<IActionResult> CloseTask(int idTask)
    {
        return await taskService.ClostTask(idTask);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("change-status-task/{idTask}")]
    public async Task<IActionResult> ChangeStatusTask(int idTask)
    {
        return await taskService.ChangeStatusTask(idTask);
    }
}
