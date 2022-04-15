using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UserMetrics
    {
        public int SevenDaySum { get; set; }
        public int ThirtyDaySum { get; set; }
        public int SumSevenDayVisits { get; set; }
        public int SumThirtyDayVisits { get; set; }
    }
}
