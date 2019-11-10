using Microsoft.EntityFrameworkCore;
using Motorport.Infrastructure.Database;
using Motorport.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class Repository<T, ID> : IRepository<T, ID> where T : class
    {
        private readonly AzureDbContext _context;

        private readonly DbSet<T> _set;

        public Repository(AzureDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ID id)
        {
            var current = _set.Find(id);
            _set.Remove(current);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Find(ID id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            return await _set.ToListAsync();
        }

        public async Task Update(ID id, T entity)
        {
            var current = await _set.FindAsync(id);
            ReflectionUtils.CopyPropertiesTo(entity, current);
            await _context.SaveChangesAsync();
        }
    }
}
