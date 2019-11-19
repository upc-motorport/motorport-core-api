using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Repositories;

namespace Motorport.Infrastructure.Services.Implementation
{
    public class DrivingSessionService : IDrivingSessionService
    {
        private readonly IDrivingSessionRepository _repository;
        public DrivingSessionService(IDrivingSessionRepository repository)
        {
            _repository = repository;
        }


        public async Task AddAsync(DrivingSession entity)
        {
            entity.Active = true;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "user";
            entity.Comments = "";
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<DrivingSession> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<DrivingSession>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(DrivingSession entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = "user";
            await _repository.UpdateAsync(entity);
        }
    }
}
