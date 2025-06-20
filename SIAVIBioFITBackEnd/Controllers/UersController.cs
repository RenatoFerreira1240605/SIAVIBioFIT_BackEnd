using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIAVIBioFITBackEnd.Data;
using SIAVIBioFITBackEnd.Models;

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

            [HttpPost]
            public async Task<ActionResult<User>> CreateUser(User user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUser), new { email = user.Email }, user);
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
