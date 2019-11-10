using System;
using System.Linq;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using EasyFinanceApi.Resources.ToModel;
using EasyFinanceApi.Resources.ToResource;
using Microsoft.EntityFrameworkCore;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ITokenRepository _tokenRepository;

        public UserRepository(AppDbContext context, ITokenRepository tokenRepository) : base(context)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<Response> Authenticate(string email, string password)
        {
            var response = new Response();

            var user = await FindUser(email, password);

            if (user == null)
                return response;

            var token = _tokenRepository.GenerateToken(user.Email, user.Password);
            response.Token = token;
            response.Role = 2;
            return response;
        }

        public async Task<User> FindUser(string email, string password)
        {
            var list = await _context.Users.Where(u => u.Email == email && u.Password == password && u.Active == true).ToListAsync();
            var user = list.FirstOrDefault();
            return user;
        }

        
    }
}
