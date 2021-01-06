using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/submissions")]
    public class SubmissionController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public SubmissionController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_appDbContext.Submissions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTrickById([FromRoute] int id)
        {
            return Ok(_appDbContext.Submissions.Where(tr => tr.Id == id));
        }

        [HttpGet("{trickId}/submissions")]
        public IActionResult ListSubmissionsForTrick([FromRoute] string trickId)
        {
            return Ok(_appDbContext.Submissions.Where(tr =>
                tr.TrickId.Equals(trickId, StringComparison.InvariantCulture)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Submission submission)
        {
            _appDbContext.Add(submission);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<Submission> Update([FromBody] Submission submission)
        {
            if (submission.Id == 0)
                return null;
            _appDbContext.Add(submission);
            await _appDbContext.SaveChangesAsync();
            return submission;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var submission = _appDbContext.Submissions.FirstOrDefault(tr => tr.Id == id && !tr.Deleted);
            if (submission == null)
                return NotFound();
            submission.Deleted = true;
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}