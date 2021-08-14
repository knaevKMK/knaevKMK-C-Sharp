using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }
        private static string CONNECTION = "Server=.\\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security= True";
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Part> Parts { get; set; }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
    //    public DbSet<PartCars> PartCars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.HasAnnotation("Relational:Collation", "SQL_latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Supplier>(entity => { });
            modelBuilder.Entity<Part>(entity => { });
            modelBuilder.Entity<Car>(entity => { });
            modelBuilder.Entity<Sale>(entity => { });
            modelBuilder.Entity<Customer>(entity => { });
   //         modelBuilder.Entity<PartCars>().HasKey(x=>new { x.PartId, x.CarId});

            base.OnModelCreating(modelBuilder);
        }
    }
}
