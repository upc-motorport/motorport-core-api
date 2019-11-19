using Microsoft.EntityFrameworkCore;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class VehicleRepository: IVehicleRepository
    {

        private readonly AzureDbContext _context;
        private readonly DbSet<Vehicle> _set;

        public VehicleRepository(AzureDbContext context)
        {
            _context = context;
            _set = _context.Set<Vehicle>();
        }

        public async Task AddAsync(Vehicle entity)
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

        public async Task<Vehicle> FindAsync(int id)
        {
            return await _set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Vehicle>> FindBySubscriptionId(int subscriptionId)
        {
            return await _set.Where(v => v.SubscriptionId == subscriptionId).ToListAsync();
        }

        public async Task<List<Vehicle>> ListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task UpdateAsync(Vehicle entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
