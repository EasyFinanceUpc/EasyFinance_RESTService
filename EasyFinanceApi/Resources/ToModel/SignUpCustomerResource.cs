using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SignUpCustomerResource
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
        public DateTime Birthday { get; set; }
    }
}
