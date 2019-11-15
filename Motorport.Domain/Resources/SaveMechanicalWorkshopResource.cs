using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Resources
{
    public class SaveMechanicalWorkshopResource
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string ImageUrl { get; set; }
        public double AverageRate { get; set; }
        [Required, MaxLength(100)]
        public string Street { get; set; }
        [Required, MaxLength(20)]
        public string StreetNumber { get; set; }
        [Required, MaxLength(20)]
        public string ZipCode { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(100)]
        public string Department { get; set; }
        [Required, MaxLength(100)]
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
