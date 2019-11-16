using Motorport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User,int>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
