using EasyFinanceApi.Resources.ToResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public interface IUserService
    {
        Task<Response> Authenticate(string email, string password);
    }
}
