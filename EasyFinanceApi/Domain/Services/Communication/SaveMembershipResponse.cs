using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveMembershipResponse : BaseResponse
    {
        public Membership Membership { get; private set; }
        private SaveMembershipResponse(bool success, string message, Membership membership) : base(success, message) 
        {
            Membership = membership;
        }
        public SaveMembershipResponse(Membership membership) : this(true, string.Empty, membership) { }
        public SaveMembershipResponse(string message) : this(false, message, null) { }
    }
}
