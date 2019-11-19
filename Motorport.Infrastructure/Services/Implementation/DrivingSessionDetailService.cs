using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Repositories;

namespace Motorport.Infrastructure.Services.Implementation
{
    public class DrivingSessionDetailService : IDrivingSessionDetailService
    {
        private readonly IDrivingSessionDetailRepository _repository;
        public DrivingSessionDetailService(IDrivingSessionDetailRepository repository) 
        {
            _repository = repository;
        }


        public async Task AddAsync(DrivingSessionDetail entity)
        {
            entity.Active = true;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "user";
            entity.Start = DateTime.Now;
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<DrivingSessionDetail> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<DrivingSessionDetail>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(DrivingSessionDetail entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = "user";
            entity.End = DateTime.Now;
            await _repository.UpdateAsync(entity);
        }
    }
}
