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
    public class AccountRepository: BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }

        public async Task<string> AddAsync()
        {
            var account = new Account();
            account.Key = Guid.NewGuid().ToString();
            account.Payment = false;
            account.CreateAt = DateTime.Now;
            await _context.Accounts.AddAsync(account);
            return account.Key;
        }

        public async Task<int> GetIdAccountAsync(string Key)
        {
            var accounts = await _context.Accounts.Where(x => x.Key == Key).ToListAsync();
            if(accounts.Count > 0)
            {
                var account = accounts.FirstOrDefault();
                return account.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
