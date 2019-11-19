using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SaveAppointmentResource
    {
        [Required]
        public DateTime ScheduleAt { get; set; }
    }
}
