using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public enum EPeriod
    {
        [Description("Week")]
        Week = 1,
        [Description("Month")]
        Month = 2,
        [Description("Year")]
        Year = 3,
    }
}
