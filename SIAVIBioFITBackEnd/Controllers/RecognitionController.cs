using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiaviBioFit.Shared.Services;
using SIAVIBioFITBackEnd.DTOs;
using SIAVIBioFITBackEnd.Utils;

namespace SIAVIBioFITBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecognitionController : ControllerBase
    {
        private readonly UserService _userService;

        public RecognitionController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Recognize([FromForm] RecognitionDto request)
        {
            var image = request.Image;

            if (image == null || image.Length == 0)
                return BadRequest("Imagem não fornecida.");

            // 1. Gravar imagem capturada
            var capturedPath = Path.Combine(Path.GetTempPath(), "captured.jpg");
            using (var stream = new FileStream(capturedPath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // 2. Obter utilizadores via serviço
            var users = await _userService.GetAllUsersAsync();

            foreach (var user in users)
            {
                if (user.FaceImage == null)
                    continue;

                var result = FaceRecognitionHelper.Run(user.FaceImage, capturedPath);

                if (result.match)
                {
                    result.email = user.Email;
                    return Ok(result);
                }
            }

            return Ok(new FaceRecognitionResult { match = false, email = null });
        }
    }
}
