using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Registry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Create_At")]
        public DateTime CreateAt { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal Amount { get; set; }
        
        [MaxLength(100)]
        public string Note { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        public Customer Customer { get; set; }
        public Category Category { get; set; }
    }
}
