using System;
using EasyFinanceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Type = EasyFinanceApi.Domain.Models.Type;

namespace EasyFinanceApi.Persistence.Context
{
    public class AppDbContext : DbContext
    { 
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountSubscription> AccountSubscriptions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Registry> Registries { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AccountSubscription>().HasKey(x => new { x.AccountId, x.SubscriptionId, x.MembershipId });

            builder.Entity<Advisor>().HasBaseType<User>();
            builder.Entity<Customer>().HasBaseType<User>();

            builder.Entity<Movement>().HasBaseType<Registry>();
            builder.Entity<Budget>().HasBaseType<Registry>();
            builder.Entity<Goal>().HasBaseType<Registry>();

            builder.Entity<Subscription>().HasData(
                new Subscription { Id = 1, Name = "Free", NumberUser = 1, Price = 0.00M },
                new Subscription { Id = 2, Name = "Micro Entrepreneur", NumberUser = 6, Price = 12.90M },
                new Subscription { Id = 3, Name = "Entrepreneur", NumberUser = 20, Price = 35.90M },
                new Subscription { Id = 4, Name = "Advisor", NumberUser = 1, Price = 6.90M }
                );

            builder.Entity<Account>().HasData (
                new Account { Id = 1, Key = "2c8bab3c-6050-4247-bba0-77777b088388", CreateAt = Convert.ToDateTime("2019-11-05"), Payment = true }
                );
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, AccountId = 1, Active = true, Birthday = Convert.ToDateTime("2019-11-05"), Email = "julio@gmail.com", Gender = EGender.Male, LastName = "Gomez", Name = "Julio", Password = "123456", Role = ERole.Owner}
                );
        }
    }
}
