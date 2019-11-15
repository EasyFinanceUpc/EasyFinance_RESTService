using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task AddAsync(Article article);
        Task<IEnumerable<Article>> GetOwnerArticles(int id);
        Task<Article> GetArticle(int id);
        void Update(Article article);
        void Delete(Article article);
    }
}
