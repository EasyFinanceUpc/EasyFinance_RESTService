using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services;
using EasyFinanceApi.Extension;
using EasyFinanceApi.Resources.ToModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinanceApi.Controllers
{
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]

    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IAdvisorService _advisorService;
        private readonly IMapper _mapper;

        public AuthenticationController(ICustomerService customerService, IUserService userService, IAdvisorService advisorService, IMapper mapper)
        {
            _customerService = customerService;
            _userService = userService;
            _advisorService = advisorService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationResource resource)
        {
            var response = await _userService.Authenticate(resource.Email, resource.Password);
            return response == null ? BadRequest(new { message = "Error login" }) : (IActionResult)Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("signup/customers")]
        public async Task<IActionResult> SignUpCustomerAsync([FromBody] SignUpCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var customer = _mapper.Map<SignUpCustomerResource, Customer>(resource);
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("signup/advisors")]
        public async Task<IActionResult> SignUpAdvisor([FromBody] SignUpAdvisorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var advisor = _mapper.Map<SignUpAdvisorResource, Advisor>(resource);
            var result = await _advisorService.SaveAsync(advisor);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }

        [HttpPost("signup/local")]
        public async Task<IActionResult> SignUpLocal([FromBody] SignUpCustomerLocalResource resource)
        {
             if (!ModelState.IsValid)
                 return BadRequest(ModelState.GetErrorMessages());
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return BadRequest("Not Claim");
            var local = _mapper.Map<SignUpCustomerLocalResource, Customer>(resource);
            var result = await _customerService.SaveAsyncLocal(local, email.Value);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok("Local Register");
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test01()
        {
            var token = Request.Headers["Authorization"];

            return Ok(token + " ");
        }
    }
}
