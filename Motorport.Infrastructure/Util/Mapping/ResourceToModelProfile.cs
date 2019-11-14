using AutoMapper;
using Motorport.Domain.Models;
using Motorport.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Infrastructure.Util.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<VehicleResource, Vehicle>();
            CreateMap<SaveVehicleResource, Vehicle>();
        }
    }
}
