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

        public async Task<Article> GetArticleResource(int id)
        {
            return await _articleRepository.GetArticle(id);
        }

        public async Task<ArticleResource> GetArticle(int id)
        {
            var article = await _articleRepository.GetArticle(id);
            if (article == null)
                return null;
            var fullName = await _advisorRepository.GetFullNameAdvisor(article.AdvisorId);
            var result = _mapper.Map<Article, ArticleResource>(article);
            result.FullNameAdvisor = fullName;
            return result;
        }

        public async Task<IEnumerable<ArticleOwnerResource>> GetArticleOwners(int id)
        {
            var articles = await _articleRepository.GetOwnerArticles(id);
            var result = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleOwnerResource>>(articles);
            return result;
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
            try
            {
                article.CreateAt = DateTime.Now;
                await _articleRepository.AddAsync(article);
                await _unitOfWork.CompleteAsync();
                return new SaveArticleResponse(article);
            } catch (Exception ex)
            {
                return new SaveArticleResponse($"An error occurred when saving the article: {ex.Message}");
            }
            
        }

        public async Task<SaveArticleResponse> Update(Article article)
        {
            try
            {
                _articleRepository.Update(article);
                await _unitOfWork.CompleteAsync();
                return new SaveArticleResponse(article);
            } catch (Exception ex)
            {
                return new SaveArticleResponse($"An error occurred when update the article: {ex.Message}");
            }
        }

        public async Task<SaveArticleResponse> Delete(int id)
        {
            try
            {
                var article = await _articleRepository.GetArticle(id);
                _articleRepository.Delete(article);
                await _unitOfWork.CompleteAsync();
                return new SaveArticleResponse(article);
            }catch (Exception ex)
            {
                return new SaveArticleResponse($"An error occurred when delete the article: {ex.Message}");
            }
        }
    }
}
