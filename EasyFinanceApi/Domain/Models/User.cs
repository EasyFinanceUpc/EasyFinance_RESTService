using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFinanceApi.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        [Column("Last_Name")]
        public string LastName { get; set; }

        public EGender Gender { get; set; }

        [Required]
        public bool Active { get; set; }

        public ERole Role { get; set; }

        public string Token { get; set; }

        [Column("Account_Id")]
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
