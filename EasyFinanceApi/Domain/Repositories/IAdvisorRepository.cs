using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IAdvisorRepository
    {
        Task AddAsync(Advisor advisor);
        Task<bool> ExistEmail(Advisor advisor);
        Task<User> GetAdvisor(string email);
        Task<string> GetFullNameAdvisor(int id);
        Task<User> GetAdvisor(int id);
    }
}
