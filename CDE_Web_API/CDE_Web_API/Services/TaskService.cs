using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface TaskService
{
 

    public Task<IActionResult> create_task(TaskDTO taskDTO, int id);

}
