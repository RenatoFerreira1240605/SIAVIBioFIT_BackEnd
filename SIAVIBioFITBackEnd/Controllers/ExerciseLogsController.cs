using Microsoft.AspNetCore.Mvc;
using SIAVIBioFITBackEnd.Models;
using SIAVIBioFITBackEnd.Services;

namespace SIAVIBioFITBackEnd.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseLogsController : ControllerBase
    {
        private readonly ExerciseLogService _service;

        public ExerciseLogsController(ExerciseLogService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> LogExercise([FromBody] ExerciseLog log)
        {
            await _service.LogExerciseAsync(log.SessionId, log.ExerciseId, log.RepetitionsCompleted, log.Success);
            return Ok();
        }

        [HttpGet("session/{sessionId}")]
        public async Task<ActionResult<List<ExerciseLog>>> GetLogsBySession(int sessionId)
        {
            var logs = await _service.GetLogsBySessionAsync(sessionId);
            return Ok(logs);
        }
    }
}
