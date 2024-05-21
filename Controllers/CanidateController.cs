using candidateapi.Business;
using candidateapi.Data;
using candidateapi.IRepository;
using candidateapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace candidateapi.Controllers
{
    [ApiController]
    [Route("candidate")]
    public class CanidateController : ControllerBase
    {
    
        private readonly ILogger<CanidateController> _logger;

        private readonly ICandidateRepository _repository;


        public CanidateController(ICandidateRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPut("addorupdate", Name = "updateCandidate")]
        public IActionResult updateCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (candidate.firstName == null || candidate.lastName == null || candidate.Email == null || candidate.freeTextComment == null)
            {
                return BadRequest("Required data should not be empty");
            }

            var result = _repository.addOrupdateData(candidate);
            if (result == true)
            {
                return Ok(_repository.getAllCandidates());
            }
            return BadRequest("Something went wrong when adding or updating data");
            
        }
    }
}
