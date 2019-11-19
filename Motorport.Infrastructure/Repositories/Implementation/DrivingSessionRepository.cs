using Microsoft.EntityFrameworkCore;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class DrivingSessionRepository : IDrivingSessionRepository
    {
        private readonly AzureDbContext _context;
        private readonly DbSet<DrivingSession> _set;

        public DrivingSessionRepository(AzureDbContext context)
        {
            _context = context;
            _set = _context.Set<DrivingSession>();
        }

        public async Task AddAsync(DrivingSession entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var current = await _set.FirstOrDefaultAsync(x => x.Id == id);
            if (current != null)
            {
                _set.Remove(current);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DrivingSession> FindAsync(int id)
        {
            return await _set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DrivingSession>> ListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task UpdateAsync(DrivingSession entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
