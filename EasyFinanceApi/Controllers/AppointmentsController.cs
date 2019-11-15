using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services;
using EasyFinanceApi.Resources.ToModel;
using EasyFinanceApi.Resources.ToResource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;
        private readonly IAdvisorService _advisorService;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, ICustomerService customerService,
            IAdvisorService advisorService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _customerService = customerService;
            _advisorService = advisorService;
            _mapper = mapper;
        }

        //For customer
        [Authorize(Roles = "1,2")]
        [HttpGet("customer")]
        public async Task<IEnumerable<AppointmentResource>> GetAppointmentsByCustomer()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return null;
            var customer = await _customerService.GetCustomer(email.Value);
            var result = await _appointmentService.GetAppointmentsByCustomer(customer.Id);
            return result;
        }

        //for advisor
        [Authorize(Roles = "3")]
        [HttpGet("advisor")]
        public async Task<IEnumerable<AppointmentResource>> GetAppointmentsByAdvisor()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return null;
            var advisor = await _advisorService.GetAdvisor(email.Value);
            var result = await _appointmentService.GetAppointmentsByAdvisor(advisor.Id);
            return result;
        }

        //for customer use
        [Authorize(Roles = "1,2")]
        [HttpGet("customer/{id}")]
        public async Task<AppointmentResource> GetAppointmentCustomer(int id)
        {
            return await _appointmentService.GetAppointmentCustomer(id);
        }

        //for advisor use
        [Authorize(Roles = "3")]
        [HttpGet("advisor/{id}")]
        public async Task<AppointmentResource> GetAppointmentAdvisor(int id)
        {
            return await _appointmentService.GetAppointmentAdvisor(id);
        }

        //Cancel Appointments
        [Authorize(Roles = "1,2,3")]
        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointment(id);
            if (appointment.Date < DateTime.Now.AddDays(3))
                return BadRequest("Pass Cancel Time");
            appointment.Status = EStatus.Cancel;
            var result = await _appointmentService.UpdateAsync(appointment, id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        //Save an Appointment
        [Authorize(Roles = "1,2")]
        [HttpPost("advisor/{id}")]
        public async Task<IActionResult> SaveAppointment(int id, [FromBody] SaveAppointmentResource resource)
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return BadRequest("Claim Error");
            var customer = await _customerService.GetCustomer(email.Value);
            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            appointment.CustomerId = customer.Id;
            appointment.AdvisorId = id;
            var result = await _appointmentService.SaveAsync(appointment);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        //Update an Appointment
        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] SaveAppointmentResource resource)
        {
            var _appointment = await _appointmentService.GetAppointment(id);
            if (_appointment.Date < DateTime.Now.AddDays(1))
                return BadRequest("Pass Update Time");

            var appointment = _mapper.Map(resource, _appointment);
            var result = await _appointmentService.UpdateAsync(appointment, id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        //Delete Appointment
        [Authorize(Roles = "1,3")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var _appointment = await _appointmentService.GetAppointment(id);
            if (_appointment.Status == EStatus.Accept)
                return BadRequest("The status is accept, you can't delete it");
            var result = await _appointmentService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }
    }
}