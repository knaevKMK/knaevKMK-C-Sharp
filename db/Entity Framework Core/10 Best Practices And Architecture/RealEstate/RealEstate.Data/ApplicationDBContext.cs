using Microsoft.EntityFrameworkCore;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
   public class ApplicationDBContext: DbContext
    {

        public ApplicationDBContext()
        {
        }
        public ApplicationDBContext(DbContextOptions options)
            :base(options)
        {

        }
    
        public DbSet<Property> Properties { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<TypeProperty> TypeProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Initial Catalog=RealEstate; Integrated Security= True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
