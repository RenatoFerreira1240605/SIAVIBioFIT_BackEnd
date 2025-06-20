using Microsoft.AspNetCore.Mvc;
using SIAVIBioFITBackEnd.Models;
using SIAVIBioFITBackEnd.Services;

namespace SIAVIBioFITBackEnd.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class SessionsController : ControllerBase
        {
            private readonly SessionService _service;

            public SessionsController(SessionService service)
            {
                _service = service;
            }

            [HttpPost("start/{email}")]
            public async Task<ActionResult<Session>> StartSession(string email)
            {
                var session = await _service.StartSessionAsync(email);
                return Ok(session);
            }

            [HttpPost("end/{sessionId}")]
            public async Task<IActionResult> EndSession(int sessionId)
            {
                await _service.EndSessionAsync(sessionId);
                return NoContent();
            }
        }
}
