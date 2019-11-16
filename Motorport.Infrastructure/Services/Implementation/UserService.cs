using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Repositories;

namespace Motorport.Infrastructure.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(User entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "user";
            entity.ModifiedAt = DateTime.Now;
            entity.Active = true;

            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<User> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<User> FindByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _repository.FindByEmailAsync(email);
            if(user != null)
            {
                bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (validPassword)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Incorrect password");
                }
            }
            throw new Exception("Incorrect email");
        }

        public async Task<List<User>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = "user";
            await _repository.UpdateAsync(entity);
        }
    }
}
