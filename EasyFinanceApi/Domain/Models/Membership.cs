using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFinanceApi.Domain.Models
{
    public class Membership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("Start_At")]
        public DateTime StartAt { get; set; }
        [Required]
        [Column("End_At")]
        public DateTime EndAt { get; set; }
    }
}
