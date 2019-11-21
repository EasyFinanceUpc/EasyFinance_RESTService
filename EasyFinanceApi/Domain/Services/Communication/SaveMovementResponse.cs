using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveMovementResponse : BaseResponse
    {
        public Movement movement { get; set; }

        private SaveMovementResponse(bool success, string message, Movement movement) : base(success, message) 
        {
            this.movement = movement;
        }

        public SaveMovementResponse(Movement movement) : this(true, string.Empty, movement) { }

        public SaveMovementResponse(string message) : this(false, message, null) { }
    }
}
