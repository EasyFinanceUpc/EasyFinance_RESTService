using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Budget : Registry
    {
        public EPeriod Period { get; set; }
        public float Save { get; set; }
    }
}
