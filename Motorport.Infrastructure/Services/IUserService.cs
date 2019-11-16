using Motorport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Services
{
    public interface IUserService : IService<User,int>
    {
        Task<User> FindByEmailAndPasswordAsync(string email, string password);
    }
}
