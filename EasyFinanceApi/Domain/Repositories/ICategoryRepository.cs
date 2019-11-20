using System;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);
    }
}
