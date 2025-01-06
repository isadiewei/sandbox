using Microsoft.AspNetCore.Mvc;
using Model;
using Service.UserTodos;

namespace React.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly ILogger<UserTaskController> _logger;
        private readonly IUserTodoService _userTaskService;

        public UserTaskController(
            ILogger<UserTaskController> logger,
            IUserTodoService userTaskService
            )
        {
            _logger = logger;
            _userTaskService = userTaskService;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserTasks([FromRoute] int userId)
        {
            try
            {
                IEnumerable<Todo> todos = await _userTaskService.GetUserTasks(userId);

                return Ok(todos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "failure to get user tasks, check service");
                return StatusCode(500, e.Message);
            }
        }
    }
}
