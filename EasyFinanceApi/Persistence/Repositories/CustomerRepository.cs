using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Users.AddAsync(customer);
        }

        public async Task<bool> ExistEmail(Customer customer)
        {
            var customers = await _context.Users.Where(x => x.Email == customer.Email).ToListAsync();
            if (customers.Count > 0)
                return true;
            else
                return false;
        }

        public async Task<int> GetOwnerAccountId(string email)
        {
            var customers = await _context.Users.Where(x => x.Email == email).ToListAsync();
            if (customers.Count <= 0)
                return 0;
            var owner = customers.FirstOrDefault();
            return owner.Id;
        }
    }
}
