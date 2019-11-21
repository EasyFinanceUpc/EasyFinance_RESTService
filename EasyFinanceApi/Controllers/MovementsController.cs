using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services;
using EasyFinanceApi.Extension;
using EasyFinanceApi.Resources.ToModel;
using EasyFinanceApi.Resources.ToResource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinanceApi.Controllers
{
    [Authorize(Roles = "1,2")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementService _movementService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public MovementsController(IMovementService movementService, ICustomerService customerService, IMapper mapper)
        {
            _movementService = movementService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost("incomes")]
        public async Task<IActionResult> AddIncomes([FromBody] SaveMovementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return BadRequest("Not Claim");
            var customer = await _customerService.GetCustomer(email.Value);
            var movement = _mapper.Map<SaveMovementResource, Movement>(resource);
            movement.CustomerId = customer.Id;
            var result = await _movementService.AddAsync(movement, 1);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        [HttpPost("expenses")]
        public async Task<IActionResult> AddExpenses([FromBody] SaveMovementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return BadRequest("Not Claim");
            var customer = await _customerService.GetCustomer(email.Value);
            var movement = _mapper.Map<SaveMovementResource, Movement>(resource);
            movement.CustomerId = customer.Id;
            var result = await _movementService.AddAsync(movement, 2);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<MovementResource>> GetMovements()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return null;
            var customer = await _customerService.GetCustomer(email.Value);
            var movements = await _movementService.GetMovements(customer.Id);
            return movements;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movementService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }
    }
}