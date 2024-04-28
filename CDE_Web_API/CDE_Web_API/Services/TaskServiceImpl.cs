using AutoMapper;
using CDE_Web_API.DTOs;
using CDE_Web_API.Helpers;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = CDE_Web_API.Models.Task;

namespace CDE_Web_API.Services;

public class TaskServiceImpl : TaskService
{
    private CDEDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IHttpContextAccessor _httpContextAccessor;
    private AuthAccountService _authAccountService;
    private IWebHostEnvironment webHostEnvironment;

    public TaskServiceImpl(
        IConfiguration configuration, 
        CDEDbContext dbContext, 
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        AuthAccountService authAccountService,
        IWebHostEnvironment _webHostEnvironment
        )
    {
       
        _configuration = configuration;
        _dbContext = dbContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _authAccountService = authAccountService;
        webHostEnvironment = _webHostEnvironment;
    }

    public async Task<IActionResult> Create_task(TaskDTO taskDTO, int id)
    {
        Models.Task task = _mapper.Map<Models.Task>(taskDTO);
        try
        {

            var visit = await _dbContext.Visits.FirstOrDefaultAsync(p => p.Id == id);
            if (visit == null)
            {
                return new BadRequestObjectResult(new { msg = "Please, choose visit!" });
            }

            var report = await _dbContext.Accounts.FirstOrDefaultAsync(s => s.Id == task.Report);
            var implement = await _dbContext.Accounts.FirstOrDefaultAsync(i => i.Id== task.Implement);
          /*  if(report.PositionGroupId != 2 || implement.PositionGroupId != 2 || report.PositionGroupId == 3 || implement.PositionGroupId == 3)
            {
                return new BadRequestObjectResult(new { msg = "Report and Implement just position sales!" });
            }*/

            task.Status = 1;
            task.VisitId = id;
           
            _dbContext.Tasks.Add(task);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult("Thêm Công việc thành công");
            }
            else
            {
                return new BadRequestObjectResult("Thêm Công việc không thành công");
            }


        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { msg = ex.Message });
        }
    }

    public dynamic Task()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Uploads_files(int idTask, List<IFormFile> filesReporter, List<IFormFile> filesImplement)
    {
        try
        {
            var task = await _dbContext.Tasks.FindAsync(idTask);
            if (task == null)
            {
                return new BadRequestObjectResult(new { msg = "File too large" });
            }

            foreach (var file in filesReporter)
            {
                if (FileHelper.checkFile(file))
                {
                    var fileName = FileHelper.generateFileName(file.FileName)!;
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "TaskFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    var fileTask = new FileTask();
                    fileTask.FileName = fileName;
                    fileTask.TaskId = idTask;
                    _dbContext.FileTasks.Add(fileTask);
                }else
                {
                    return new BadRequestObjectResult(new { msg = "File Invalid" });
                }
                
            }
            foreach (var file in filesImplement)
            {
                if (FileHelper.checkFile(file))
                {
                    var fileName = FileHelper.generateFileName(file.FileName)!;
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "TaskFile", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    var fileTask = new FileTask();
                    fileTask.FileName = fileName;
                    fileTask.TaskId = idTask;
                    _dbContext.FileTasks.Add(fileTask);
                }
                else
                {
                    return new BadRequestObjectResult("File Invalid");
                }
            }

            if(await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult("Successful! TheFileHasBeenUploadedSuccessfully");
            }else
            {
                return new BadRequestObjectResult("Failed! TheFileHasBeenUploadedFailed");
            }
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new {ex.Message});
        }
    }

    public async Task<IActionResult> CommentTask(int idTask, RateDTO rateDTO)
    {
        Rate rate = _mapper.Map<Rate>(rateDTO);
        try
        {
            var userLogin = _dbContext.Accounts.FirstOrDefault(a => a.Email == _authAccountService.getAccount());
            var task = await _dbContext.Tasks.FindAsync(idTask);
            if (task == null)
            {
                return new BadRequestObjectResult(new { msg = "Task not found!" });
            }

            if(rate.RateValue > 5)
            {
                return new BadRequestObjectResult(new { msg = "Rate Invalid!" });
            }

            rate.Created = DateTime.Now;
            rate.RaterAccountId = userLogin.Id;
            rate.TaskId = idTask;
            _dbContext.Rates.Add(rate);
            if(await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult(true);
            }else
            {
                return new BadRequestObjectResult(false);
            }
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new {ex.Message});
        }
    }

    public async Task<IActionResult> ClostTask(int idTask)
    {
        try
        {
            var task = await _dbContext.Tasks.FindAsync(idTask);
            if(task == null)
            {
                return new BadRequestObjectResult(new { msg = "Task not found!" });
            }

            task.Status = 5;
            _dbContext.Entry(task).State = EntityState.Modified;
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult("Successful! EditTaskSuccess");
            }
            else
            {
                return new BadRequestObjectResult(new { msg = false });
            }
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new { ex.Message });
        }
    }

    public async Task<IActionResult> ChangeStatusTask(int idTask)
    {
        try
        {
            var task = await _dbContext.Tasks.FindAsync(idTask);
            if (task == null)
            {
                return new BadRequestObjectResult(new { msg = "Task not found!" });
            }

            switch (task.Status)
            {
                case 1: task.Status = 2; break;
                case 2: task.Status = 3; break;
                case 3: task.Status = 4; break;
            }
            _dbContext.Entry(task).State = EntityState.Modified;
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new OkObjectResult("Successful! EditTaskSuccess");
            }
            else
            {
                return new BadRequestObjectResult(new { msg = false });
            }
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { ex.Message });
        }
    }
}
