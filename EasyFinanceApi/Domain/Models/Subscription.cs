using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFinanceApi.Domain.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        [Range(0.01, 120.00)]
        public decimal Price { get; set; }
        [Required]
        [Column("Number_User")]
        [Range(0, int.MaxValue)]
        public int NumberUser { get; set; }
    }
}
