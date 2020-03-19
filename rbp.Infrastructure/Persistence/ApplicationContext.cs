using Microsoft.EntityFrameworkCore;
using rbp.Domain;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
