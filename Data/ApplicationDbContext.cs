using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KmakPortal.Models;

namespace KmakPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for enumerations
            modelBuilder.Entity<UnitOfMeasure>().HasData(
                new UnitOfMeasure { Id = 1, Name = "Kilogram" },
                new UnitOfMeasure { Id = 2, Name = "Liter" },
                new UnitOfMeasure { Id = 3, Name = "Piece" }
            );

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "Pending" },
                new OrderStatus { Id = 2, Name = "Approved" },
                new OrderStatus { Id = 3, Name = "Delivered" },
                new OrderStatus { Id = 4, Name = "Confirmed" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Production" },
                new Department { Id = 2, Name = "Purchasing" }
            );
        }

    }
}
