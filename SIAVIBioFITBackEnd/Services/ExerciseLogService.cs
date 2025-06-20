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
    public class ExerciseLogService
    {
        private readonly BioFitContext _context;

        public ExerciseLogService(BioFitContext context)
        {
            _context = context;
        }

        public async Task LogExerciseAsync(int sessionId, int exerciseId, int reps, bool success)
        {
            var log = new ExerciseLog
            {
                SessionId = sessionId,
                ExerciseId = exerciseId,
                RepetitionsCompleted = reps,
                Success = success,
                LoggedAt = DateTime.Now
            };

            _context.ExerciseLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExerciseLog>> GetLogsBySessionAsync(int sessionId)
        {
            return await _context.ExerciseLogs
                .Where(e => e.SessionId == sessionId)
                .Include(e => e.Exercise)
                .ToListAsync();
        }
    }
}
