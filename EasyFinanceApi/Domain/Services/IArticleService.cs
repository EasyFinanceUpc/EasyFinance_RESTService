using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services.Communication;
using EasyFinanceApi.Resources.ToResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleResource>> GetArticles();
        Task<IEnumerable<ArticleOwnerResource>> GetArticleOwners(int id);
        Task<SaveArticleResponse> SaveArticle(Article article);
        Task<ArticleResource> GetArticle(int id);
        Task<SaveArticleResponse> Update(Article article);
        Task<Article> GetArticleResource(int id);
        Task<SaveArticleResponse> Delete(int id);
    }
}
