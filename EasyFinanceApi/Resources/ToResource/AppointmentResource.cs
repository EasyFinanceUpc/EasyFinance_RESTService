using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Resources.ToResource
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public EStatus Status { get; set; }
        public int AdvisorId { get; set; }
        public string AdvisorName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Email { get; set; }
    }
}
