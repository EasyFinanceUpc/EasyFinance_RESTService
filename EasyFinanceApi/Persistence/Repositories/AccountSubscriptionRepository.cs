using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class AccountSubscriptionRepository : BaseRepository, IAccountSubscriptionRepository
    {
        public AccountSubscriptionRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(int membershipId, int accountId, int subscriptionId)
        {
            var account = new AccountSubscription();
            account.AccountId = accountId;
            account.MembershipId = membershipId;
            account.SubscriptionId = subscriptionId;
            await _context.AccountSubscriptions.AddAsync(account);
        }
    }
}
