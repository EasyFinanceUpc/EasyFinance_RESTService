using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        [Required]
        [Column("Create_At")]
        public DateTime CreateAt { get; set; }
        [Column("Advisor_Id")]
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }
    }
}
