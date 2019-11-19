using Motorport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Domain.Resources
{
    public class DrivingSessionDetailResource
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Distance { get; set; }
        public int HardBrakingCount { get; set; }
        public double Acceleration { get; set; }
        public double Speed { get; set; }
    }
}

