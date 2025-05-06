using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Repos.Services;
using ViewModels;

namespace Presentation22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task1Controller : ControllerBase
    {
        private readonly ITask1 taskRepo;

        public Task1Controller(ITask1 taskRepo)
        {
            this.taskRepo = taskRepo;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(
      [FromQuery] Task1Status? status = null,
      [FromQuery] string? searchTitle = null,
      [FromQuery] int page = 1,
      [FromQuery] int pageSize = 10)
        {
            var tasks = await taskRepo.GetTasksAsync(status, searchTitle, page, pageSize);
           

            return Ok(new
            {
                Data = tasks,
                Page = page,
                PageSize = pageSize
            });
        }

        [HttpPost("Add")]
        public async Task <IActionResult> Add(Addtask task1)
        {
            var task2 = new Task1 {
                Title = task1.Title,
                Description= task1.Description,
                DueDate = task1.DueDate,
                Status= task1.Status, 
                PriorityLevel=task1.p
                

            
            };
          await  taskRepo.Add(task2);
            return Ok();
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> getbyid(int id)
        {
            var item =await taskRepo.getbyid(id);
            return Ok(item);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> delete(int id)
        {
          await  taskRepo.Delete(id);
            return Ok();

            
        }
        [HttpPut("wdit")]
        public async Task<IActionResult> update(int id,Addtask task)
        {
            var item =await taskRepo.getbyid(id);
            item.Title = task.Title;
            item.Description = task.Description;
            item.DueDate = task.DueDate;
            item.Status = task.Status;
            item.PriorityLevel = task.p;
          await  taskRepo.update(item);
            return Ok();

        }

    }
}
