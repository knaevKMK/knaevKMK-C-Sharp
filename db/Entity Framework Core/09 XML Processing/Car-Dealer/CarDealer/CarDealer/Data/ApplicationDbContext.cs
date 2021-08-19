using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static string CONNECTION = "Server=.\\SQLEXPRESS;Database=CarDealer2;Trusted_Connection =True";
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Supplier>(entity => { });
          
            modelBuilder.Entity<Car>(entity => { });
            modelBuilder.Entity<Sale>(entity => { });
            modelBuilder.Entity<Customer>(entity => { });

            modelBuilder.Entity<PartCar>()
                .HasKey(pc => new { pc.CarId, pc.PartId });

            modelBuilder.Entity<Part>(entity => {
                entity.HasKey(p => p.Id);
                entity.HasOne(e => e.Supplier)
                .WithMany(e => e.Parts)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                

                });
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
