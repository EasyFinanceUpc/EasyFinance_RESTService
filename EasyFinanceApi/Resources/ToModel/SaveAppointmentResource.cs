using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SaveAppointmentResource
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int AdvisorId { get; set; }
    }
}
