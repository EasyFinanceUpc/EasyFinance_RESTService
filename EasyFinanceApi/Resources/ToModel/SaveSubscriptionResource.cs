using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SaveSubscriptionResource
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N}")]
        [Range(0.01, 120.00)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int NumberUser { get; set; }
    }
}
