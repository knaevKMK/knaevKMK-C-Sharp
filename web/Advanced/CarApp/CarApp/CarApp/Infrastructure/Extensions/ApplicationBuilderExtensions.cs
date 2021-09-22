
namespace CarApp.Infrastructure.Extensions
{

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using CarApp.Data;
    using CarApp.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            var data = services.GetRequiredService<ApplicationDbContext>();
            data.Database.EnsureCreated();
            MigrateDataBase(services);

            SeedCategories(services);
        //    SeedAdministrator(services);

            return app;
        }

        //private static void SeedAdministrator(IServiceProvider services)
        //{
        //    var userManager = services.GetRequiredService<UserManager<User>>();
        //    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        //    Task
        //        .Run(async () =>
        //        {
        //            if (await roleManager.RoleExistsAsync(AdministratorRoleName))
        //            {
        //                return;
        //            }

        //            var role = new IdentityRole { Name = AdministratorRoleName };

        //            await roleManager.CreateAsync(role);

        //            const string adminEmail = "admin@crs.com";
        //            const string adminPassword = "admin12";

        //            var user = new User
        //            {
        //                Email = adminEmail,
        //                UserName = adminEmail,
        //                FullName = "Admin"
        //            };

        //            await userManager.CreateAsync(user, adminPassword);

        //            await userManager.AddToRoleAsync(user, role.Name);
        //        })
        //        .GetAwaiter()
        //        .GetResult();
        //}

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(
                new Category {Name="Mini" },
                new Category {Name="Economy" },
                new Category {Name="Midsize" },
                new Category {Name="Limosine" },
                new Category {Name="SUV" },
                new Category {Name="Vans" },
                new Category {Name="Luxury" }
                );
            data.SaveChanges();

        }

        private static void MigrateDataBase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            data.Database.Migrate();
        }
    }
}
