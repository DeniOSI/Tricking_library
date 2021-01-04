using Microsoft.AspNetCore.Mvc;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "What the fuck????";
        }
    }
}