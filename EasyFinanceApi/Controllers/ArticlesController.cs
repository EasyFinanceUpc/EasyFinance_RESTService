using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services;
using EasyFinanceApi.Extension;
using EasyFinanceApi.Resources.ToModel;
using EasyFinanceApi.Resources.ToResource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFinanceApi.Controllers
{
    [Authorize(Roles = "3")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IAdvisorService advisorService, IArticleService articleService, IMapper mapper)
        {
            _advisorService = advisorService;
            _articleService = articleService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ArticleResource>> GetActicles()
        {
            return await _articleService.GetArticles();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var result = await _articleService.GetArticle(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsyncArticle([FromBody] SaveArticleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            if (email == null)
                return BadRequest("Not Claim");

            var advisor = await _advisorService.GetAdvisor(email.Value);
            var article = _mapper.Map<SaveArticleResource, Article>(resource);
            article.AdvisorId = advisor.Id;
            var result = await _articleService.SaveArticle(article);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleOwnerResource>(result.Article);
            return Ok(articleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncArticle(int id, [FromBody] SaveArticleResource resource)
        {
            var article = await _articleService.GetArticleResource(id);
            if (article == null)
                return NotFound();
            var _result = _mapper.Map(resource, article);
            var result = await _articleService.Update(_result);
            if (!result.Success)
                return BadRequest(result.Message);
            var resultArticle = _mapper.Map<Article, ArticleOwnerResource>(result.Article);
            return Ok(resultArticle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncArticle(int id)
        {
            var result = await _articleService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok("Delete");
        }

        [HttpGet("owner")]
        public async Task<IEnumerable<ArticleOwnerResource>> GetArticlesByAdvisor()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
            var advisor = await _advisorService.GetAdvisor(email.Value);
            var results = await _articleService.GetArticleOwners(advisor.Id);
            return results;
        }
    }
}