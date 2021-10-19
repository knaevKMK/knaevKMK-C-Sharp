using EvnWithAngular.Data;
using EvnWithAngular.Models.Entites;
using EvnWithAngular.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EvnWithAngular.Infrastructure
{
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
