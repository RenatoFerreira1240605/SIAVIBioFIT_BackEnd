using Microsoft.EntityFrameworkCore;
using SIAVIBioFITBackEnd;
using SIAVIBioFITBackEnd.Data;
using SIAVIBioFITBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaviBioFit.Shared.Services
{
    public class UserService
    {
        private readonly BioFitContext _context;

        public UserService(BioFitContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FindAsync(email);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email)) return false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateLoginStatsAsync(string email)
        {
            var user = await _context.Users.FindAsync(email);
            if (user != null)
            {
                user.LoginCount++;
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementLevelAndScore(string email)
        {
            var user = await _context.Users.FindAsync(email);
            if (user != null)
            {
                user.Level++;
                user.Score += 100;
                await _context.SaveChangesAsync();
            }
        }
    }
}
