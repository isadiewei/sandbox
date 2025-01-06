using Microsoft.AspNetCore.Mvc;
using NLog;

namespace React.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(
            ILogger<ErrorController> logger
            ) 
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AlwaysError()
        {
            try
            {
                _logger.LogTrace("Inside AlwaysError()");

                int x = 4;
                int y = 5;
                int z = x + y;

                string sumMessage = $"The sum of {x} and {y} is {z}";

                _logger.LogInformation(sumMessage);

                throw new Exception("Should Always Fail, For Testing Only");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Found an Error");
                return StatusCode(500, "Exception Logged");
            }
        }
    }
}
