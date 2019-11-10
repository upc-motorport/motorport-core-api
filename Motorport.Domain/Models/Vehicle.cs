﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Motorport.Domain.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RegistrationPlate { get; set; }

        [Required]
        public int SubscriptionId { get; set; }

        [Required, MaxLength(50)]
        public string Model { get; set; }

        [Required, MaxLength(50)]
        public string Brand { get; set; }

        [Required,MaxLength(50)]
        public string Type { get; set; }

        public int Year { get; set; }

        public int Kilometers { get; set; }

        [MaxLength(200)]
        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public bool Active { get; set; }
    }
}
