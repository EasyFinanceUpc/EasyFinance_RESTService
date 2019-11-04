using System;
using EasyFinanceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyFinanceApi.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Test>().HasData (
                new Test { Id = 1, Description = "Prueba 01", Name = "Test 01" },
                new Test { Id = 2, Description = "Prueba 02", Name = "Test 02" },
                new Test { Id = 3, Description = "Prueba 03", Name = "Test 03" },
                new Test { Id = 4, Description = "Prueba 04", Name = "Test 04" },
                new Test { Id = 5, Description = "Prueba 05", Name = "Test 05" }
            );
        }
    }
}
