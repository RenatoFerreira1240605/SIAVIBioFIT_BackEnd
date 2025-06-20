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
    public class SessionService
    {
        private readonly BioFitContext _context;

        public SessionService(BioFitContext context)
        {
            _context = context;
        }

        public async Task<Session> StartSessionAsync(string userEmail)
        {
            var session = new Session
            {
                UserEmail = userEmail,
                StartedAt = DateTime.Now
            };

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task EndSessionAsync(int sessionId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session != null)
            {
                session.EndedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
    }
}
