using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;
using EasyFinanceApi.Resources.ToResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IAdvisorRepository advisorRepository,
            ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _advisorRepository = advisorRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentResource>> GetAppointmentsByCustomer(int id) 
        {
            var appointments = await _appointmentRepository.GetAppointmentByCustomer(id);
            var result = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            foreach(AppointmentResource appointment in result)
            {
                appointment.CustomerName = await _customerRepository.GetCustomerFullName(appointment.CustomerId);
                appointment.AdvisorName = await _advisorRepository.GetFullNameAdvisor(appointment.AdvisorId);
            }
            return result;

        }

        public async Task<IEnumerable<AppointmentResource>> GetAppointmentsByAdvisor(int id) 
        {
            var appointments = await _appointmentRepository.GetAppointmentByAdvisor(id);
            var result = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            foreach(AppointmentResource appointment in result)
            {
                appointment.CustomerName = await _customerRepository.GetCustomerFullName(appointment.CustomerId);
                appointment.AdvisorName = await _advisorRepository.GetFullNameAdvisor(appointment.AdvisorId);
            }
            return result;
        }

        public async Task<AppointmentResource> GetAppointmentCustomer(int id) 
        {
            var appointment = await _appointmentRepository.GetAppointment(id);
            var result = _mapper.Map<Appointment, AppointmentResource>(appointment);
            var advisor = await _advisorRepository.GetAdvisor(appointment.AdvisorId);
            result.AdvisorName = await _advisorRepository.GetFullNameAdvisor(appointment.AdvisorId);
            result.Email = advisor.Email;
            return result;
        }
        public async Task<AppointmentResource> GetAppointmentAdvisor(int id) 
        {
            var appointment = await _appointmentRepository.GetAppointment(id);
            var result = _mapper.Map<Appointment, AppointmentResource>(appointment);
            result.CustomerName = await _customerRepository.GetCustomerFullName(appointment.CustomerId);
            return result;
        }
        public async Task<SaveAppointmentResponse> SaveAsync(Appointment appointment) 
        {
            try
            {
                appointment.Status = EStatus.Accept;
                await _appointmentRepository.SaveAsync(appointment);
                await _unitOfWork.CompleteAsync();
                return new SaveAppointmentResponse(appointment);
            } catch (Exception ex)
            {
                return new SaveAppointmentResponse($"An error occurred when save the appointment: {ex.Message}");
            }
        }
        public async Task<SaveAppointmentResponse> UpdateAsync(Appointment appointment, int id) 
        {
            try
            {
                var temp = await _appointmentRepository.GetAppointment(id);
                var result = _mapper.Map(appointment, temp);
                _appointmentRepository.UpdateAsync(result);
                await _unitOfWork.CompleteAsync();
                return new SaveAppointmentResponse(result);
            } catch (Exception ex)
            {
                return new SaveAppointmentResponse($"An error occurred when update the appointment: { ex.Message}");
            }
        }
        public async Task<SaveAppointmentResponse> DeleteAsync(int id) 
        {
            try
            {
                var appointment = await _appointmentRepository.GetAppointment(id);
                _appointmentRepository.DeleteAsync(appointment);
                await _unitOfWork.CompleteAsync();
                return new SaveAppointmentResponse(appointment);
            }catch(Exception ex)
            {
                return new SaveAppointmentResponse($"An error occurred when delete the appointment: { ex.Message}");
            }
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await _appointmentRepository.GetAppointment(id);
        }
    }
}
