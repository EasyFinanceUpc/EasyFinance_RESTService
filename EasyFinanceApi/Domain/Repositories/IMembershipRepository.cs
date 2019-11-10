using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IMembershipRepository
    {
        Task<DateTime> AddAsync();
        Task<int> GetIdMembershipAsync(DateTime now);
    }
}
