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
    }
}
