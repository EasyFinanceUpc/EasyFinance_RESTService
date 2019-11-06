using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFinanceApi.Domain.Models
{
    public class AccountSubscription
    {
        [Column("Account_Id")]
        public int AccountId { get; set; }
        [Column("Subscription_Id")]
        public int SubscriptionId { get; set; }
        [Column("Membership_Id")]
        public int MembershipId { get; set; }

        public Account Account { get; set; }
        public Membership Membership { get; set; }
        public Subscription Subscription { get; set; }
    }
}
