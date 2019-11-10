using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Advisor : User
    {
        [MaxLength(200)]
        [MinLength(5)]
        public string Description { get; set; }
        [Range(0,60)]
        public int Experience { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        public string University { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IList<Article> Articles { get; set; } = new List<Article>();
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
