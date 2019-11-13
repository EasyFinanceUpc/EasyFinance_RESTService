using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class AdvisorRepository : BaseRepository, IAdvisorRepository
    {
        public AdvisorRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Advisor advisor)
        {
            await _context.Users.AddAsync(advisor);
        }
        public async Task<bool> ExistEmail(Advisor advisor)
        {
            var advisors = await _context.Users.Where(x => x.Email == advisor.Email).ToListAsync();
            if (advisors.Count > 0)
                return true;
            else
                return false;
        }

        public async Task<User> GetAdvisor(string email)
        {
            var advisors = await _context.Users.Where(x => x.Email == email).ToListAsync();
           
            if (advisors.Count > 0)
            {
                var advisor = advisors.FirstOrDefault();
                return advisor;
            }
            else
                return null;
        }

        public async Task<string> GetFullNameAdvisor(int id)
        {
            var advisors = await _context.Users.Where(x => x.Id == id).ToListAsync();
            
            if (advisors.Count > 0)
            {
                var advisor = advisors.FirstOrDefault();
                var fullName = advisor.Name + " " + advisor.LastName;
                return fullName;
            }   
            else
                return null;
        }
    }
}
