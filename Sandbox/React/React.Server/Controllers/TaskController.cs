using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Todos;
using Service.UserTodos;

namespace React.Server.Controllers
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITodoService _todoService;
        private readonly IUserTodoService _userTodosService;

        public TaskController(
            ILogger<TaskController> logger, 
            ITodoService todoService,
            IUserTodoService userTaskService
            )
        {
            _logger = logger;
            _todoService = todoService;
            _userTodosService = userTaskService;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                IEnumerable<Todo> result = await _todoService.ReadTodos();

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get tasks");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            try
            {
                bool? result = await _todoService.CreateTodo(todo);
                bool response = result.HasValue && result.Value;

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "failed to create a task");
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("[controller]/delete/{todoId}")]
        public async Task<IActionResult> DeleteTodo(int todoId)
        {
            try
            {
                int? result = await _todoService.DeleteTodo(todoId);

                if (!result.HasValue)
                {
                    _logger.LogTrace($"error deleting todo {todoId}");
                    return StatusCode(500, $"there was an error deleting the todo {todoId}");
                }

                return Ok(result.Value);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"failed to delete todo");
                return StatusCode(500, e.Message);
            }
        }
    }
}
