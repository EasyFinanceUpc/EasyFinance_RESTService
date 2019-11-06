using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Goal : Registry
    {
        [Column("Reach_At")]
        public DateTime ReachAt { get; set; }
    }
}
