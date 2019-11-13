using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Resources.ToResource
{
    public class ArticleResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int AdvisorId { get; set; }
        public string FullNameAdvisor { get; set; }
    }
}
