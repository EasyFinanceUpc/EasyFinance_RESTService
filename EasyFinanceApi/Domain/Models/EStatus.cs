using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public enum EStatus
    {
        [Description("Accept")]
        Accept = 1,
        [Description("Cancel")]
        Cancel = 2,
        [Description("On Hold")]
        On_Hold = 3,
    }
}
