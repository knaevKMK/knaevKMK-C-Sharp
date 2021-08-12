using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext()
        {
                    }
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }
        private static string CONNECTION = "Server=.\\SQLEXPRESS;Initial Catalog= ProductShop; Integrated Security= True";
       
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                            {
                optionsBuilder.UseSqlServer(CONNECTION);
         //       optionsBuilder.UseLazyLoadingProxies().UseSqlServer(CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_latin1_General_CP1_CI_AS");
            modelBuilder.Entity<User>(entity=> {
           
            });

            modelBuilder.Entity<Product>(entity=> {
           //     entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Category>(entity=> { 
            //entity.Property(x => x.Id).ValueGeneratedOnAdd();
             });
            
                base.OnModelCreating(modelBuilder);
        }
    }
}
