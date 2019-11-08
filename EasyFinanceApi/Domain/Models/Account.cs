using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFinanceApi.Domain.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Create_At")]
        public DateTime CreateAt { get; set; }
        [Required]
        public bool Payment { get; set; }
        public IList<User> Users { get; set; } = new List<User>();
    }
}
