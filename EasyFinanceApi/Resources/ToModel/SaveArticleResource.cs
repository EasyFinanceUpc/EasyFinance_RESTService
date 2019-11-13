using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SaveArticleResource
    {
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string Title { get; set; }
        [Required]
        [MaxLength(8000)]
        [MinLength(400)]
        public string Body { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(20)]
        public string Description { get; set; }
    }
}
