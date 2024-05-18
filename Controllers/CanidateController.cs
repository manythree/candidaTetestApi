using candidateapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace candidateapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CanidateController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CanidateController> _logger;

        public CanidateController(ILogger<CanidateController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCandidates")]
        public IEnumerable<Candidate> GetCandidates()
        {
            return null;
        }
    }
}
