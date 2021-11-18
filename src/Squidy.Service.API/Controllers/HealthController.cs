using Microsoft.AspNetCore.Mvc;

namespace Squidy.Services.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHealth")]
        public IActionResult Get()
        {
            return Ok("I'm alive!");
        }
    }
}