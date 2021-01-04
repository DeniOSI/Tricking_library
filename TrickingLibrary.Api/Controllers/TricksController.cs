using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using TrickingLibrary.Api.Models;
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
            this._appDbContext = appDbContext;
        }

        // api/tricks
        [HttpGet]
        public IActionResult Get() => Ok( _appDbContext.Tricks.ToList() );

        // api/tricks/1
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
           return Ok(_appDbContext.Tricks.Where(tr=>tr.Id ==id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Trick trick)
        {
            _appDbContext.Add(trick);
            await  _appDbContext.SaveChangesAsync();
            return Ok();
        }

        // [HttpPut]
        // public void Update(Trick trick)
        // {
        //     
        // }
        
    }
}