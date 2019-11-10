using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IAccountSubscriptionRepository
    {
        Task AddAsync(int membershipId, int accountId, int subscriptionId);
    }
}
