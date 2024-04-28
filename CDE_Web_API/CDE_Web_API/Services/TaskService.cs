using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface TaskService
{
    public dynamic Task();
    public Task<IActionResult> Create_task(TaskDTO taskDTO, int id);

    public Task<IActionResult> Uploads_files(int idTask, List<IFormFile> filesReporter, List<IFormFile> filesImplement);

    public Task<IActionResult> CommentTask(int idTask, RateDTO rateDTO);

    public Task<IActionResult> ClostTask(int idTask);
    public Task<IActionResult> ChangeStatusTask(int idTask);

}
