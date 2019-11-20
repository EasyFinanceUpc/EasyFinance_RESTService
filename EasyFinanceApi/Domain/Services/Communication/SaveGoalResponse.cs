using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveGoalResponse : BaseResponse
    {
        public Goal goal { get; private set; }

        private SaveGoalResponse(bool success, string message, Goal goal) : base(success, message)
        {
            this.goal = goal;
        }

        public SaveGoalResponse(Goal goal) : this(true, string.Empty, goal) { }

        public SaveGoalResponse(string message) : this(false, message, null) { }
    }
}
