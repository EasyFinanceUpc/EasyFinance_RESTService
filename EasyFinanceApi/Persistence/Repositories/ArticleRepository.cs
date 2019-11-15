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
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Article article)
        {
            await _context.Articles.AddAsync(article); 
        }

        public async Task<Article> GetArticle(int id)
        {
            var result =  await _context.Articles.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetOwnerArticles(int id)
        {
            return await _context.Articles.Where(x => x.AdvisorId == id).ToListAsync();
        }

        public void Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            
        }

        public void Delete(Article article)
        {
            _context.Articles.Remove(article);
        }
    }
}
