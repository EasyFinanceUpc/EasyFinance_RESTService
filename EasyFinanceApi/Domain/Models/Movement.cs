using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Movement : Registry
    {
        [Column("Type_Id")]
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
