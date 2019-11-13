using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Customer : User
    {
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public IList<Registry> Registries { get; set; } = new List<Registry>();
    }
}
