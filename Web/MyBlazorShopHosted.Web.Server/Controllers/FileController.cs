using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyBlazorShopHosted.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// An instance of <see cref="IWebHostEnvironment"/>
        /// </summary>
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// A new instance of <see cref="FileController"/>
        /// </summary>
        /// <param name="environment">An instance of <see cref="IWebHostEnvironment"/></param>
        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        /// <summary>
        /// Uploads a file up to the server
        /// </summary>
        /// <param name="files">The files to upload</param>
        /// <returns>A response about the upload</returns>        
        [HttpPost("upload")]
        public async Task<ActionResult> UploadAsync(List<IFormFile> files)
        {
            // Populate into uploads folder
            var folderPath = Path.Combine(_environment.ContentRootPath, "uploads");

            if (!Directory.Exists(folderPath))
            {
                // Create directory if it does not exist.
                Directory.CreateDirectory(folderPath);
            }

            foreach (var file in files)
            {
                // Get full file path
                var path = Path.Combine(folderPath, file.FileName);

                // Upload file (if path doesn't exist)
                if (!System.IO.File.Exists(path))
                {
                    await using FileStream fs = new(path, FileMode.Create);
                    await file.CopyToAsync(fs);
                }
            }

            return Ok();
        }
    }
}
