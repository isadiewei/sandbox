using Microsoft.AspNetCore.Mvc;
using Model;
using Service.UserTask;

namespace Sandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IUserTaskService _userTaskService;

        public TaskController(
            ILogger<TaskController> logger, 
            IUserTaskService userTaskService
            )
        {
            _userTaskService = userTaskService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                IEnumerable<Todo> result = await _userTaskService.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get tasks");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Todo todo)
        {
            try
            {
                bool? result = await _userTaskService.CreateTodo(todo);
                bool response = result.HasValue && result.Value;

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "failed to create a task");
                return StatusCode(500, e.Message);
            }
        }
    }
}
