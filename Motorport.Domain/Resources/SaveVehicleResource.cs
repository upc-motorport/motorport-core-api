using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Resources
{
    public class SaveVehicleResource
    {
        public string RegistrationPlate { get; set; }

        public int? SubscriptionId { get; set; }

        [Required, MaxLength(50)]
        public string Model { get; set; }

        [Required, MaxLength(50)]
        public string Brand { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; }

        public int? Year { get; set; }

        public int? Kilometers { get; set; }

        [MaxLength(200)]
        public string ImageUrl { get; set; }
    }
}
