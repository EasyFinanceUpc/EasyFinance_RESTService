using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Resources.ToResource
{
    public class GoalResource
    {
        public DateTime CreateAt { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
        public int Category { get; set; }
        public string Color { get; set; }
        public DateTime ReachAt { get; set; }
    }
}
