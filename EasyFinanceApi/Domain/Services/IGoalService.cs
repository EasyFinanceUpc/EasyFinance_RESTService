using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services 
{ 
    public interface IGoalService
    {
        Task<SaveGoalResponse> AddGoal(Goal goal);
    }
}
