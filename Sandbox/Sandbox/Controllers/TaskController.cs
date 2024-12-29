using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace Sandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public TaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
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
                return StatusCode(500, e.Message);
            }
        }
    }
}
