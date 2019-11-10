using Motorport.Domain.Models;
using Motorport.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Infrastructure.Repositories.Implementation
{
    public class VehicleRepository: Repository<Vehicle,int>,IVehicleRepository
    {
        public VehicleRepository(AzureDbContext context): base(context)
        {

        }
    }
}
