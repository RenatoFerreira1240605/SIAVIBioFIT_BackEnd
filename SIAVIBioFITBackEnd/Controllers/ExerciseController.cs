using Microsoft.AspNetCore.Mvc;
using SIAVIBioFITBackEnd.Models;
using SIAVIBioFITBackEnd.Services;

namespace SIAVIBioFITBackEnd.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class ExercisesController : ControllerBase
        {
            private readonly ExerciseService _service;

            public ExercisesController(ExerciseService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<ActionResult<List<Exercise>>> GetAll()
            {
                return await _service.GetAllAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Exercise>> GetById(int id)
            {
                var exercise = await _service.GetByIdAsync(id);
                return exercise == null ? NotFound() : Ok(exercise);
            }
        }
}
