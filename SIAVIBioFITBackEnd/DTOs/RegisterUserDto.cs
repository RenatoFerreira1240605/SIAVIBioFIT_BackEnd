namespace SIAVIBioFITBackEnd.DTOs
{
    public class RegisterUserDto
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
