using Microsoft.EntityFrameworkCore;
using Pizzeria.Domain.Models;

namespace Pizzeria.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = 1,
                    PlateNumber = "NP-500-NC",
                    ReleaseYear = 2005,
                    Model = "Renault Clio"
                },
                new Vehicle()
                {
                    Id = 2,
                    PlateNumber = "NP-600-NL",
                    ReleaseYear = 2008,
                    Model = "Volkswagen Golf 5"
                }
                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza()
                {
                    Id = 1,
                    Name = "Capricoza",
                    PricePerUnit = 3.5m,
                    Size = 28,
                    Additives = "Shrooms, Bacon, Mozarella Cheese, Tomato Sauce"
                },
                 new Pizza()
                 {
                     Id = 2,
                     Name = "Fungi",
                     PricePerUnit = 2.5m,
                     Size = 28,
                     Additives = "Shrooms, Mozarella Cheese"
                 }
                );
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Customer",
                },
                new Role()
                {
                    Id = 2,
                    Name = "Baker",
                },
                new Role()
                {
                    Id = 3,
                    Name = "Delivery",
                }
                );
        }
    }
}
