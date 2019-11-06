using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public EStatus Status { get; set; }
        [Column("Advisor_Id")]
        public int AdvisorId { get; set; }
        [Column("Customer_Id")]
        public int CustomerId { get; set; }
        public Advisor Advisor { get; set; }
        public Customer Customer { get; set; }
    }
}
