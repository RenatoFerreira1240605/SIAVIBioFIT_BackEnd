using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiaviBioFit.Shared.Services;
using SIAVIBioFITBackEnd.Data;
using SIAVIBioFITBackEnd.DTOs;
using SIAVIBioFITBackEnd.Models;
using System.Xml.Linq;

namespace SIAVIBioFITBackEnd.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly BioFitContext _context;

        public UsersController(BioFitContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            var user = await _context.Users
                .Include(u => u.Sessions)
                .FirstOrDefaultAsync(u => u.Email == email);

            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("register")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Register([FromForm] RegisterUserDto request)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Faces");
            Directory.CreateDirectory(path);
            var imagePath = Path.Combine(path, "reference.jpg");

            using var memoryStream = new MemoryStream();
            await request.Image.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();


            var user = new User
            {
                Email = request.Email,
                Name = request.Name,
                Age = request.Age,
                Gender = request.Gender,
                Level = 1,
                LoginCount = 1,
                Score = 0,
                RegisteredAt = DateTime.UtcNow,
                FaceImage = imageBytes
            };

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                return Conflict("Utilizador já existe");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateUser(string email, User updatedUser)
        {
            if (email != updatedUser.Email)
                return BadRequest();

            _context.Entry(updatedUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
