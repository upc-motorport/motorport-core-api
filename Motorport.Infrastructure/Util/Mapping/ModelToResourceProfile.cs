using AutoMapper;
using Motorport.Domain.Models;
using Motorport.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Infrastructure.Util.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Vehicle, VehicleResource>();
            CreateMap<Vehicle, SaveVehicleResource>();
            CreateMap<User, UserResource>();
            CreateMap<MechanicalWorkshop, MechanicalWorkshopResource>();
        }
    }
}
