using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services.Communication;
using EasyFinanceApi.Resources.ToResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResource>> GetAppointmentsByCustomer(int id);
        Task<IEnumerable<AppointmentResource>> GetAppointmentsByAdvisor(int id);
        Task<AppointmentResource> GetAppointmentCustomer(int id);
        Task<AppointmentResource> GetAppointmentAdvisor(int id);
        Task<SaveAppointmentResponse> SaveAsync(Appointment appointment);
        Task<SaveAppointmentResponse> UpdateAsync(Appointment appointment, int id);
        Task<SaveAppointmentResponse> DeleteAsync(int id);
        Task<Appointment> GetAppointment(int id);
    }
}
