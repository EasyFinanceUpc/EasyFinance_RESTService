using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services;
using EasyFinanceApi.Extension;
using EasyFinanceApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CustomerRequest resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var customer = _mapper.Map<CustomerRequest, Customer>(resource);
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);
            return Ok();
        }
    }
}