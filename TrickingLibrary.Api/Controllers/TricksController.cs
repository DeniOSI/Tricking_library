using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/tricks")]
    public class TricksController : ControllerBase
    {
        private readonly TrickyStore _trickyStore;

        public TricksController(TrickyStore trickyStore)
        {
            this._trickyStore = trickyStore;
        }

        // api/tricks
        [HttpGet]
        public IActionResult Get() => Ok( _trickyStore.All());

        // api/tricks/1
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
           return Ok(_trickyStore.All().FirstOrDefault(x=>x.Id.Equals(id)));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Trick trick)
        {
            _trickyStore.Add(trick); 
            return Ok();
        }

        // [HttpPut]
        // public void Update(Trick trick)
        // {
        //     
        // }
        
    }
}