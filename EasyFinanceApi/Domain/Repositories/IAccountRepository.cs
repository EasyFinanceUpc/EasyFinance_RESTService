using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<string> AddAsync();
        Task<int> GetIdAccountAsync(string Key);
    }
}
