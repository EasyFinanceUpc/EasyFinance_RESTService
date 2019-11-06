using System;
using System.ComponentModel.DataAnnotations;

namespace EasyFinanceApi.Resources.ToModel
{
    public class SignUpAdvisorResource
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
        [MaxLength(200)]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(60)]
        public int Experience { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string University { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
