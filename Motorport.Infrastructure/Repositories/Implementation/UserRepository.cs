using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Database;

namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly AzureDbContext _context;
        private readonly DbSet<User> _set;

        public UserRepository(AzureDbContext context)
        {
            _context = context;
            _set = _context.Set<User>();
        }

        public async Task AddAsync(User entity)
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

        public async Task<User> FindAsync(int id)
        {
            return await _set.Include(u => u.Person).Include(u => u.Membership).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> ListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
