using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Repositories
{
    public interface IRepository<T,ID>
    {
        Task AddAsync(T entity);

        Task<T> FindAsync(ID id);

        Task<List<T>> ListAsync();

        Task UpdateAsync(T entity);

        Task DeleteAsync(ID id);
    }
}
