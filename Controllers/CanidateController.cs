using candidateapi.Business;
using candidateapi.Data;
using candidateapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace candidateapi.Controllers
{
    [ApiController]
    [Route("candidate")]
    public class CanidateController : ControllerBase
    {
    
        private readonly ILogger<CanidateController> _logger;

        private readonly BusinessCandidate businessCandidate ; 


        public CanidateController(BusinessCandidate BusinessCandidate)
        {
            businessCandidate = BusinessCandidate;
        }
        
        [HttpGet(Name = "getCandidates")]
        public ActionResult<List<Candidate>> getCandidates()
        {
            return Ok(this.businessCandidate.getAllCandidates());
        }
        
        [HttpPost("add", Name = "addCandidate")]
        public IActionResult addCandidate([FromBody]Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reslult = this.businessCandidate.addCandidate(candidate);
            if (reslult == true)
            {
                return Ok();
            }

            return BadRequest("Try Again!");
        }

        [HttpPut("update", Name = "updateCandidate")]
        public IActionResult updateCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = this.businessCandidate.updateData(candidate);
            if (result == true)
            {
                return Ok();
            }
            return BadRequest("Data wan't updated");
            
        }
    }
}
