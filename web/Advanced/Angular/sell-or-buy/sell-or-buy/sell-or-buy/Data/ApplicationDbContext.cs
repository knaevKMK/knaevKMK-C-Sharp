namespace sell_or_buy.Data
{
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    using sell_or_buy.Data.Models.Entities;
    using sell_or_buy.Data.Models.Identity;
    using sell_or_buy.Data.Models.Categories;
    public class ApplicationDbContext : IdentityDbContext<UserBase>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<UserApp> Accounts { get; set; }
        DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vehicles>(entity =>
            {
                entity
                    .HasOne(v => v.Creator)
                    .WithMany()
                    .HasForeignKey(v => v.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
