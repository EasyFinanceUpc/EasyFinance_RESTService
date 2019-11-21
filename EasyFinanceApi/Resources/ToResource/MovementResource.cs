using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Resources.ToResource
{
    public class MovementResource
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
    }
}
