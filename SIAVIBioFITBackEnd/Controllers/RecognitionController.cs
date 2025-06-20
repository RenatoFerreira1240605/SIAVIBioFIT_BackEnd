using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIAVIBioFITBackEnd.Utils;

namespace SIAVIBioFITBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionController : ControllerBase
    {
        [HttpPost]
        [Route("api/recognize")]
        public async Task<IActionResult> Recognize(IFormFile image)
        {
            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Temp");
            Directory.CreateDirectory(uploadsPath);

            var imagePath = Path.Combine(uploadsPath, "captured.jpg");
            using var stream = new FileStream(imagePath, FileMode.Create);
            await image.CopyToAsync(stream);

            var result = FaceRecognitionHelper.Run(imagePath);

            return Ok(new
            {
                match = result.match,
                email = result.email
            });
        }
    }
}
