using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
