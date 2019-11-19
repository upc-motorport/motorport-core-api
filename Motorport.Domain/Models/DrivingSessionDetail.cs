using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Models
{
    public class DrivingSessionDetail
    {
        [Key]
        public int Id { get; set; }
        public int DrivingSessionId { get; set; }
        public DrivingSession DrivingSession { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Distance { get; set; }
        public int HardBrakingCount { get; set; }
        public double Acceleration { get; set; }
        public double Speed { get; set; }
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
