using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCleanArchitecture.Core.Orders;

namespace MyCleanArchitecture.EFCore
{
    public class MyCleanArchitectureDBContext : DbContext
    {
        public MyCleanArchitectureDBContext(DbContextOptions<MyCleanArchitectureDBContext> options) :base(options)
        {

        }
        public DbSet<OrderLog> OrderLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderLog>()
                .HasIndex(o => new { o.OrderId })
                .IsUnique(true);

            base.OnModelCreating(builder);
        }
    }
}
