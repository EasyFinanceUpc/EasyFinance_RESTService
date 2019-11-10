using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Resources.Helpers;
using EasyFinanceApi.Resources.ToModel;
using EasyFinanceApi.Resources.ToResource;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Authenticate(string email, string password)
        { 
            var response = await _userRepository.Authenticate(email, password);
            return response;
        }
    }
}
