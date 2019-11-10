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
    [Authorize]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(ICustomerService customerService, IUserService userService, IMapper mapper)
        {
            _customerService = customerService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
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

        [HttpGet("test")]
        public async Task<IActionResult> Test01()
        {
            var token = Request.Headers["Authorization"];

            return Ok(token + " ");
        }
    }
}
