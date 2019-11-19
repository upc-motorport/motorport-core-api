using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class DrivingSession
    {
        [Key]
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageAcceleration { get; set; }
        public double TotalReaction { get; set; }
        public int TotalHardBracking { get; set; }
        public double TotalDistance { get; set; }
        [MaxLength(200)]
        public string Comments { get; set; }
        public List<DrivingSessionDetail> DrivingSessionDetails { get; set; }
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
