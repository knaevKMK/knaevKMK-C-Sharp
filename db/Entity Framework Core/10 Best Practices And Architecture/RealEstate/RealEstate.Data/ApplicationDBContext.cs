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
        public DbSet<PropertiesTags> PropertiesTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Initial Catalog=RealEstate; Integrated Security= True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(p => p.PropertyId).HasColumnName("PropertyID");

            });

            modelBuilder.Entity<PropertiesTags>()
                .HasKey(k => new { k.PropertyId, k.TagId });
            modelBuilder.Entity<PropertiesTags>()
             .HasOne(p => p.Property)
             .WithMany(t => t.PropertiesTags)
             .HasForeignKey(t => t.PropertyId);

            modelBuilder.Entity<PropertiesTags>()
                .HasOne(p => p.Tag)
                .WithMany(t => t.PropertiesTags)
                .HasForeignKey(t => t.TagId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
