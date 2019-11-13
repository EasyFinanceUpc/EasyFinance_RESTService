using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public enum EType
    {
        [Description("Income")]
        Income = 1,
        [Description("Expense")]
        Expense = 2
    }
}
