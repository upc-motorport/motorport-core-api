using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class MechanicalWorkshop
    {
        [Key]
        public int? Id { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
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
 
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
        #region "Common Fields"
        public DateTime CreatedAt { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public bool Active { get; set; }
        #endregion
    }
}
