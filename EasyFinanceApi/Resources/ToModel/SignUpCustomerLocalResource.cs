using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SignUpCustomerLocalResource
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
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        public int Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
