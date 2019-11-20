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
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GoalsController(IGoalService goalService, ICustomerService customerService, IMapper mapper)
        {
            _goalService = goalService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveGoalResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return BadRequest("Not Claim");
            var customer = await _customerService.GetCustomer(email.Value);
            var goal = _mapper.Map<SaveGoalResource, Goal>(resource);
            goal.CustomerId = customer.Id;
            var result = await _goalService.AddGoal(goal);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<GoalResource>> GetGoal()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return null;
            var customer = await _customerService.GetCustomer(email.Value);
            return await _goalService.GetGoals(customer.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _goalService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReachGoal(int id)
        {
            var result = await _goalService.Update(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }
    }
}