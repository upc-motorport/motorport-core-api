using Microsoft.EntityFrameworkCore;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class DrivingSessionDetailRepository : IDrivingSessionDetailRepository
    {
        private readonly AzureDbContext _context;
        private readonly DbSet<DrivingSessionDetail> _set;

        public DrivingSessionDetailRepository(AzureDbContext context)
        {
            _context = context;
            _set = _context.Set<DrivingSessionDetail>();

        }


        public async Task AddAsync(DrivingSessionDetail entity)
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

        public async Task<DrivingSessionDetail> FindAsync(int id)
        {
            return await _set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DrivingSessionDetail>> ListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task UpdateAsync(DrivingSessionDetail entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
