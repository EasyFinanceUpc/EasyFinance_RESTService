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
        //private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        /*public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }*/

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Authenticate(string email, string password)
        { 
            /*var user = new AuthenticationResource();

            //authenticate with customer
            //authenticate with advisor
            //authenticate with admin

            //inicio
            if (email != "admin@admin.com" || password != "123456")
            {
                return response;
            }

            user.Email = email;
            user.Password = password;
            //fin

            //if (user == null)
            //    return response;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Name, user.Password.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Token = tokenHandler.WriteToken(token);
            response.Role = 2;

            return response;*/

            var response = await _userRepository.Authenticate(email, password);
            return response;
        }
    }
}
