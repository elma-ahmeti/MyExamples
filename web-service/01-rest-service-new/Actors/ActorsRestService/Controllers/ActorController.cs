using Microsoft.AspNetCore.Mvc;

namespace ActorsRestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ActorController> _logger;

        public ActorController(ILogger<ActorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetActors")]
        public IEnumerable<string> GetActors()
        {
            string[] result = new string[2];
            result[0] = "actor Bata Zivojinovic";
            result[1] = "actor John Wayne";
            return result;
        }

    }
}