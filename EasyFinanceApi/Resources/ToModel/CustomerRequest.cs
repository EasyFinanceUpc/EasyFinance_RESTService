using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Resources
{
    public class CustomerRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        [MinLength(6)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(18)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Gender { get; set; }

        [Required]
        public bool Active { get; set; }

        public int Role { get; set; }

        [Required]
        public string Token { get; set; }

        public int AccountId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
