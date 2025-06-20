using Microsoft.AspNetCore.Mvc;

namespace SIAVIBioFITBackEnd.DTOs
{
    public class RecognitionDto
    {
        [FromForm(Name = "image")]
        public IFormFile Image { get; set; } = null!;
    }
}
