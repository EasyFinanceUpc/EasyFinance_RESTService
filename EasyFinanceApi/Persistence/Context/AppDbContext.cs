using System;
using Microsoft.EntityFrameworkCore;

namespace EasyFinanceApi.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //public db aca
    }
}
