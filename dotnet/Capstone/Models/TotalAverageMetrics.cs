using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class TotalAverageMetrics
    {
        public int TotalAverageSevenDaySum { get; set; }
        public int TotalAverageThirtyDaySum { get; set; }
        public int TotalAverageSevenDayVisits { get; set; }
        public int TotalAverageThirtyDayVisits { get; set; }
        public int TotalUserCount { get; set; }
    }
}
