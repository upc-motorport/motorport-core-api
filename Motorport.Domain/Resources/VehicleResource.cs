using Motorport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Domain.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public Subscription Subscription { get; set; }

        public string RegistrationPlate { get; set; }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public int? Year { get; set; }

        public int? Kilometers { get; set; }

        public string ImageUrl { get; set; }
    }
}
