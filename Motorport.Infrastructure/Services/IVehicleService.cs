using Motorport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motorport.Infrastructure.Services
{
    public interface IVehicleService: IService<Vehicle,int>
    {
        Task<List<Vehicle>> FindBySubscriptionId(int subscriptionId);
    }
}
