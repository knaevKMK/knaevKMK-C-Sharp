using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Views.ImoprtDto;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(e=> {
                e.HasKey(pc=>new { pc.CarId, pc.PartId});
            });
        }
        public DbSet<WebApplication3.Views.ImoprtDto.CarDto> CarDto { get; set; }
    }
}
