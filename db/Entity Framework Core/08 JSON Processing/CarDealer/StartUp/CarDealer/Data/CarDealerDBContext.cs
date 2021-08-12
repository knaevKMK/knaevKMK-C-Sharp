using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data
{
    class CarDealerDBContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        private static string SERVER_CONNECTION = "Server=.\\SQLEXPRESS;Database=CarDealer;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SERVER_CONNECTION);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PartCar>()
                .HasKey(x => new {x.CarId, x.PartId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
