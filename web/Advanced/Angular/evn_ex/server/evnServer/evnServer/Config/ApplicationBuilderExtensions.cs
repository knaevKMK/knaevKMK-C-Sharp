

namespace evnServer.Config
{
    using System;
    using System.Linq;
    using evnServer.Data;
    using evnServer.Model.Entity;
    using evnServer.Model.Enums;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder PrepareDatabse(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            data.Database.EnsureCreated();
            data.Database.Migrate();
            
            seedData(data);

            return app;
        }

        private static void seedData(ApplicationDbContext data)
        {
            if (data.Departments.Any())
            {
                return;
            }
            foreach (var departmentEnum in Enum.GetValues<DepartmentEnum>())
            {
                data.Departments.Add(new Department()
                {
                    Name = departmentEnum.ToString(),
                    Code = (int)departmentEnum
                });

                data.SaveChanges();
            }
        }
    }
}
