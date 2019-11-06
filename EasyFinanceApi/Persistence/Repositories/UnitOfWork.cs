using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using System.Threading.Tasks;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
