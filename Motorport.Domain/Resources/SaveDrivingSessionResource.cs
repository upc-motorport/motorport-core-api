using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motorport.Domain.Resources
{
    public class SaveDrivingSessionResource
    {
        public double AverageSpeed { get; set; }
        public double AverageAcceleration { get; set; }
        public double TotalReaction { get; set; }
        public int TotalHardBracking { get; set; }
        public double TotalDistance { get; set; }
        [MaxLength(200)]
        public string Comments { get; set; }
    }
}
