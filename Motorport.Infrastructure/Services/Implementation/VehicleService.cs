﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Motorport.Domain.Models;
using Motorport.Infrastructure.Repositories;

namespace Motorport.Infrastructure.Services.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Vehicle entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "user";
            entity.ModifiedAt = DateTime.Now;
            entity.Active = true;
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Vehicle> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<Vehicle>> FindBySubscriptionId(int subscriptionId)
        {
            return await _repository.FindBySubscriptionId(subscriptionId);
        }

        public async Task<List<Vehicle>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(Vehicle entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = "user";
            await _repository.UpdateAsync(entity);
        }
    }
}
