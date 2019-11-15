using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<bool> ExistEmail(Customer customer);
        Task<int> GetOwnerAccountId(string email);
        Task<string> GetCustomerFullName(int id);
        Task<User> GetCustomer(int id);
        Task<User> GetCustomerEmail(string email);
    }
}
