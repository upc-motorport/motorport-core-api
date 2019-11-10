using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Repositories
{
    public interface IRepository<T,ID>
    {
        Task Add(T entity);

        Task<T> Find(ID id);

        Task<List<T>> List();

        Task Update(ID id, T entity);

        Task Delete(ID id);
    }
}
