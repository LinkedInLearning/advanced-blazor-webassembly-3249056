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
        /// <param name="file">The file</param>
        /// <returns>A response about the upload</returns>
        public async Task<ActionResult> UploadAsync(IFormFile file)
        {
            // Get a random file name
            var fileName = Path.GetRandomFileName();

            // Populate into uploads folder
            var folderPath = Path.Combine(_environment.ContentRootPath, "uploads");

            if (!Directory.Exists(folderPath))
            {
                // Create directory if it does not exist.
                Directory.CreateDirectory(folderPath);
            }

            // Get full file path
            var path = Path.Combine(folderPath, fileName);

            // Upload file
            await using FileStream fs = new(path, FileMode.Create);
            await file.CopyToAsync(fs);

            return Ok(new { Filename = fileName });
        }
    }
}
