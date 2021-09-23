using Microsoft.EntityFrameworkCore;
using CarApp.Services.Car.Model;
namespace CarApp.Data
{
using CarApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : IdentityDbContext<UserApp>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Dealer> Dealers { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Car>()
                .HasOne(c => c.Dealer)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>();

            builder.Entity<Dealer>()
                .HasOne<UserApp>()
                .WithOne()
                .HasForeignKey<Dealer>(d=>d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
        public DbSet<CarApp.Services.Car.Model.CarDetailsServiceModel> CarDetailsServiceModel { get; set; }
    }
}
