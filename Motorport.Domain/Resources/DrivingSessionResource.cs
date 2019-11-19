using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Domain.Resources
{
    public class DrivingSessionResource
    {
        public int Id { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageAcceleration { get; set; }
        public double TotalReaction { get; set; }
        public int TotalHardBracking { get; set; }
        public double TotalDistance { get; set; }
        public string Comments { get; set; }

    }
}
