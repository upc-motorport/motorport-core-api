using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Motorport.Domain.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName ="decimal(9,2)")]
        public double Cost { get; set; }

        [Required]
        public int UsersLimit { get; set; }

        [Required]
        public int PlanType { get; set; }

        public List<Subscription> Subscriptions { get; set; }

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
