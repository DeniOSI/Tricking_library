using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/videos")]
    public class VideosController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHost;

        public VideosController(IWebHostEnvironment webHost)
        {
            this._webHost = webHost;
        }
        [HttpPost]
        public async Task<IActionResult> UploadVideo(IFormFile video)
        {
            var mimeType = video.FileName.Split('.').Last();
            var fileName = string.Concat(Path.GetRandomFileName().Replace('.', '_'), '.', mimeType);
            var filePath = string.Concat(_webHost.WebRootPath,'/', fileName);
            await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await video.CopyToAsync(fileStream);
            return Ok();
        }
    }
}