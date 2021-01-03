using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using TrickingLibrary.Core.Enum;
using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;

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

        [HttpGet("{video}")]
        public IActionResult GetVideo(string video)
        {
            var mimeType = video.Split('.').Last();
            var filePath = string.Concat(_webHost.WebRootPath, '/', video);
            return new FileStreamResult(new FileStream(filePath, FileMode.Open, FileAccess.Read), MimeTypes.Video);
        }

        [HttpPost]
        public async Task<IActionResult> UploadVideo(IFormFile video)
        {
            var mimeType = video.FileName.Split('.').Last();
            var fileName = string.Concat(Path.GetRandomFileName().Replace('.', '_'), '.', mimeType);
            var filePath = string.Concat(_webHost.WebRootPath, '/', fileName);
            await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await video.CopyToAsync(fileStream);
            return Ok(fileName);
        }
    }
}