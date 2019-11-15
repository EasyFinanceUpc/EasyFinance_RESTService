using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services.Communication
{
    public class SaveArticleResponse : BaseResponse
    {
        public Article Article { get; private set; }
        private SaveArticleResponse(bool success, string message, Article article) : base(success, message)
        {
            Article = article;
        }

        public SaveArticleResponse(Article article) : this(true, string.Empty, article) { }
        public SaveArticleResponse(string message) : this(false, message, null) { }
    }
}
