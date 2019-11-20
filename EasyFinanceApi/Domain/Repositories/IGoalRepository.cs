using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IGoalRepository
    {
        Task AddAsync(Goal goal);
        Task<IEnumerable<Goal>> GetGoals(int id);
        Task<Goal> GetGoal(int id);
        void Delete(Goal goal);
        void Update(Goal goal);
    }
}
