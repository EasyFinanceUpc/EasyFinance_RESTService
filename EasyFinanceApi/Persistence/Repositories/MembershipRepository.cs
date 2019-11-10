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
    public class MembershipRepository : BaseRepository, IMembershipRepository
    {
        public MembershipRepository(AppDbContext context): base(context)
        {
        }

        public async Task<DateTime> AddAsync()
        {
            var membership = new Membership();
            membership.StartAt = DateTime.Now;
            membership.EndAt = membership.StartAt.AddMonths(1);
            await _context.Memberships.AddAsync(membership);
            return membership.StartAt;
        }

        public async Task<int> GetIdMembershipAsync(DateTime now)
        {
            var memberships = await _context.Memberships.Where(x => x.StartAt == now).ToListAsync();
            if(memberships.Count > 0)
            {
                var membership = memberships.FirstOrDefault();
                var id = membership.Id;
                return id;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
