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
        public IActionResult GetTrickById([FromRoute] int id)
        {
            return Ok(_appDbContext.Tricks.Where(tr => tr.Id == id));
        }

        [HttpGet("{trickid}/submissions")]
        public IActionResult ListSubmissionsForTrick([FromRoute] int trickid)
        {
            return Ok(_appDbContext.Submissions.Where(tr => tr.TrickId == trickid));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Trick trick)
        {
            _appDbContext.Add(trick);
            await _appDbContext.SaveChangesAsync();
            return Ok(trick.Id);
        }

        [HttpPut]
        public async Task<Trick> Update(Trick trick)
        {
            if (trick.Id == 0)
                return null;
            _appDbContext.Add(trick);
            await _appDbContext.SaveChangesAsync();
            return trick;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var trick = _appDbContext.Tricks.FirstOrDefault(tr => tr.Id == id && !tr.Deleted);
            if (trick == null)
                return NoContent();
            trick.Deleted = true;
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}