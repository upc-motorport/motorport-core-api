using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }

        public List<Membership> Memberships { get; set; }

        public List<Vehicle> Vehicles { get; set; }

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
