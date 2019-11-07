using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public CustomerController(ICustomerService customerService, IUserService userService, IMapper mapper)
        {
            _customerService = customerService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SignUpCustomerResource resource)
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
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationResource resource)
        {
            var response = _userService.Authenticate(resource.Email, resource.Password);
            if (response == null)
                return BadRequest(new { message = "Error login" });
            return Ok(response);
        }

        [HttpGet("test")]
        public IActionResult Test01()
        {
            var token = Request.Headers["Authorization"];

            return Ok("bearer " + token);
        }
    }
}