using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveAdvisorResponse : BaseResponse
    {
        public Advisor Advisor { get; private set; }
        private SaveAdvisorResponse(bool success, string message, Advisor advisor) : base(success, message) 
        {
            Advisor = advisor;
        }

        public SaveAdvisorResponse(Advisor advisor) : this(true, string.Empty, advisor) { }
        public SaveAdvisorResponse(string message) : this(false, message, null) { }
    }
}
