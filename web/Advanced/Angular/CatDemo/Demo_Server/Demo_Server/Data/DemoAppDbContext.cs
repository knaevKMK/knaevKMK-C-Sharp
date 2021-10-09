namespace Demo_Server.Data
{
    using Demo_Server.Data.Model;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    public class DemoAppDbContext : IdentityDbContext<User>
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Item>(entity=> {
                entity.HasKey(i => i.Id);
            });
            base.OnModelCreating(builder);
        }
    }
}
