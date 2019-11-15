using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base (context) { }

        public async Task<IEnumerable<Appointment>> GetAppointmentByAdvisor(int id)
        {
            return await _context.Appointments.Where(x => x.AdvisorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByCustomer(int id)
        {
            return await _context.Appointments.Where(x => x.CustomerId == id).ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            var result = await _context.Appointments.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task SaveAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public void UpdateAsync(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
        }

        public void DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }
    }
}
