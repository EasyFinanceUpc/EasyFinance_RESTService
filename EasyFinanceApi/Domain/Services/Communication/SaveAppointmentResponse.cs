using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveAppointmentResponse : BaseResponse
    {
        public Appointment Appointment { get; private set; }

        private SaveAppointmentResponse(bool success, string message, Appointment appointment) : base(success, message)
        {
            Appointment = appointment;
        }

        public SaveAppointmentResponse(Appointment appointment) : this(true, string.Empty, appointment) { }

        public SaveAppointmentResponse(string message) : this(false, message, null) { }
    }
}
