using Microsoft.EntityFrameworkCore;
using SIAVIBioFITBackEnd;
using SIAVIBioFITBackEnd.Data;
using SIAVIBioFITBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAVIBioFITBackEnd.Services
{
    public class ExerciseService
    {
        private readonly BioFitContext _context;

        public ExerciseService(BioFitContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }
    }
}
