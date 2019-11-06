using EasyFinanceApi.Resources.Helpers;
using EasyFinanceApi.Resources.ToResource;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public async Task<Response> Authenticate(string email, string password)
        {
            var response = new Response();
            //= findby(email).first
            var user = 4;
            
            if (user == null)
                return response;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, "adf")
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Token = tokenHandler.WriteToken(token);

            return response;
        }
    }
}
