using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [AllowAnonymous]
        [HttpGet]
        public  async Task<IActionResult> GetActicles()
        {
            //getAllArticles()
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsyncArticle()
        {
            //save Article
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateAsyncArticle(int id)
        {
            //update Article
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteAsyncArticle(int id)
        {
            //delete Article
        }

        [HttpGet("/owner")]
        public async Task<IActionResult> GetArticlesByAdvisor()
        {
            //getArticlesByAdvisor(email string)
        }
    }
}