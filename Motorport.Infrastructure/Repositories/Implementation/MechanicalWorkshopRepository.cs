using Microsoft.EntityFrameworkCore;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motorport.Domain.Models;

namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class MechanicalWorkshopRepository : IMechanicalWorkshopRepository
    {
        private readonly AzureDbContext _context;
        private readonly DbSet<MechanicalWorkshop> _set;

        public MechanicalWorkshopRepository(AzureDbContext context)
        {
            _context = context;
            _set = _context.Set<MechanicalWorkshop>();
        }



        public async Task AddAsync(MechanicalWorkshop entity)
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

        public async Task<MechanicalWorkshop> FindAsync(int id)
        {
            return await _set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MechanicalWorkshop>> ListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task UpdateAsync(MechanicalWorkshop entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
