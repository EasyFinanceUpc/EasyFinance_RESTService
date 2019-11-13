using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;
using EasyFinanceApi.Resources.ToResource;

namespace EasyFinanceApi.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IAdvisorRepository advisorRepository, IArticleRepository articleRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _advisorRepository = advisorRepository;
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleResource>> GetArticles()
        {
            var articles = await _articleRepository.GetArticles();
            var result = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);
            foreach(ArticleResource article in result)
            {
                article.FullNameAdvisor = await _advisorRepository.GetFullNameAdvisor(article.AdvisorId);
            }
            return result;
        }

        public async Task<SaveArticleResponse> SaveArticle(Article article)
        {
            article.CreateAt = DateTime.Now;
            await _articleRepository.AddAsync(article);
            await _unitOfWork.CompleteAsync();
            return new SaveArticleResponse(article);
        }
    }
}
