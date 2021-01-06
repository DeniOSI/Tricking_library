using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/tricks")]
    public class TricksController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public TricksController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_appDbContext.Tricks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTrickById([FromRoute] string id)
        {
            return Ok(_appDbContext.Tricks.Where(tr => tr.Id.Equals(id, StringComparison.InvariantCulture)));
        }

        [HttpGet("{trickid}/submissions")]
        public IActionResult ListSubmissionsForTrick([FromRoute] string trickid)
        {
            return Ok(_appDbContext.Submissions.Where(tr =>
                tr.TrickId.Equals(trickid, StringComparison.InvariantCulture)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Trick trick)
        {
            trick.Id = trick.Name.Replace(" ", "_").ToLowerInvariant();
            _appDbContext.Add(trick);
            await _appDbContext.SaveChangesAsync();
            return Ok(trick.Id);
        }

        [HttpPut]
        public async Task<Trick> Update(Trick trick)
        {
            if (string.IsNullOrEmpty(trick.Id))
                return null;
            _appDbContext.Add(trick);
            await _appDbContext.SaveChangesAsync();
            return trick;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var trick = _appDbContext.Tricks.FirstOrDefault(tr =>
                tr.Id.Equals(id, StringComparison.InvariantCulture) && !tr.Deleted);
            if (trick == null)
                return NoContent();
            trick.Deleted = true;
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}