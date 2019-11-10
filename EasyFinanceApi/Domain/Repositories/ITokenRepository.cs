using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface ITokenRepository
    { 
        string GenerateToken(string email, int role);
    }
}
