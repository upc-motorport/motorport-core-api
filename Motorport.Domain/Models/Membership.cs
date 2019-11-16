using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public RoleEnum Role { get; set; }

        public int SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

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
