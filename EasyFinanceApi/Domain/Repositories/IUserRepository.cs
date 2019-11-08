using System;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Resources.ToResource;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindUser(string email, string password);
        Task<Response> Authenticate(string email, string password);
    }
}
