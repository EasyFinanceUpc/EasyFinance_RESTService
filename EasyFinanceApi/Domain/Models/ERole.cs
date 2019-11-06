using System.ComponentModel;

namespace EasyFinanceApi.Domain.Models
{
    public enum ERole
    {
        [Description("Owner")]
        Owner = 1,
        [Description("Member")]
        Member = 2,
        [Description("Advisor")]
        Advisor = 3,
        [Description("Admin")]
        Admin = 4
    }
}
