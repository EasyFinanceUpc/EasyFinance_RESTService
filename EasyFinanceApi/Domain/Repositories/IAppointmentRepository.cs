using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentByCustomer(int id);
        Task<IEnumerable<Appointment>> GetAppointmentByAdvisor(int id);
        Task<Appointment> GetAppointment(int id);
        Task SaveAsync(Appointment appointment);
        void UpdateAsync(Appointment appointment);
        void DeleteAsync(Appointment appointment);
    }
}
