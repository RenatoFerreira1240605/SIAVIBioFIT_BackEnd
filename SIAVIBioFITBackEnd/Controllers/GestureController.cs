using Microsoft.AspNetCore.Mvc;
using SIAVIBioFITBackEnd.Models;

[ApiController]
[Route("api/[controller]")]
public class GestureController : ControllerBase
{
    private static Dictionary<string, int> exerciseCounters = new();

    [HttpPost("submit")]
    public IActionResult SubmitReps([FromBody] RepetitionData data)
    {
        if (string.IsNullOrWhiteSpace(data.Exercise)) return BadRequest("Exercise is required");

        exerciseCounters[data.Exercise] = data.Repetitions;
        return Ok(new { Message = "Data received", Reps = data.Repetitions });
    }

    [HttpGet("get/{exercise}")]
    public IActionResult GetReps(string exercise)
    {
        if (exerciseCounters.TryGetValue(exercise, out var reps))
            return Ok(new { Exercise = exercise, Reps = reps });

        return NotFound("Exercise not found");
    }
}
