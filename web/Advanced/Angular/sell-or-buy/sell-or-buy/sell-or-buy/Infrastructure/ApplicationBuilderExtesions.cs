namespace sell_or_buy.Infrastructure
{
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using sell_or_buy.Data;
    public static class ApplicationBuilderExtesions
    {

        public static void ApplyMigrations(this IApplicationBuilder app)
        {

            using var services = app.ApplicationServices.CreateScope();

            var db = services.ServiceProvider.GetService<ApplicationDbContext>();
            db.Database.EnsureCreated();
            db.Database.Migrate();
        }
    }
}
