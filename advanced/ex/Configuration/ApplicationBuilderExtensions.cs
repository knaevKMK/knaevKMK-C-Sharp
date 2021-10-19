

namespace ex.Configuration
{
    using ex.Data;
    using ex.Models;
    using ex.Models.Enums;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            seedDepartment(services);
          
            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void seedDepartment(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Departments.Any())
            {
                return;
            }

          
               foreach (var departEnum in Enum.GetValues<DepartmentEnum>())
                {
                data.Departments.Add(new Department()
                {
                    Name = departEnum.ToString(),
                    Code = (int)departEnum
                });
                data.SaveChanges();
            }
        }

    }
}
