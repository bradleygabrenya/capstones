using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UseTracking
    {
        public int TrackingId { get; set; }
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
        public int EquipmentId { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public DateTime UseStart { get; set; }
        public DateTime UseStop { get; set; }

    }
}
