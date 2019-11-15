using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Repositories;

namespace Motorport.Infrastructure.Services.Implementation
{
    public class MechanicalWorkshopService : IMechanicalWorkshopService
    {
        private readonly IMechanicalWorkshopRepository _repository;

        public MechanicalWorkshopService(IMechanicalWorkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(MechanicalWorkshop entity)
        {
            entity.Active = true;
            entity.AverageRate = 0;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "user";
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<MechanicalWorkshop> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<MechanicalWorkshop>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(MechanicalWorkshop entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = "user";
            await _repository.UpdateAsync(entity);
        }
    }
}
