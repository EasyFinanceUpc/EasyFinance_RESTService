using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveCustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }
        private SaveCustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            Customer = customer;
        }
        public SaveCustomerResponse(Customer customer) : this(true, string.Empty, customer) { }
        public SaveCustomerResponse(string message) : this(false, message, null) { }
    }
}
