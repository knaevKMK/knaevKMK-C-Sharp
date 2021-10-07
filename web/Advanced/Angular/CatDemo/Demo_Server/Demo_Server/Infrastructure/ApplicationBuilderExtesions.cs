using Demo_Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Server.Infrastructure
{
    public static class ApplicationBuilderExtesions
    {
        public static void ApplyMigrations(this IApplicationBuilder app) {
            using var services = app.ApplicationServices.CreateScope();

            var db = services.ServiceProvider.GetService<DemoAppDbContext>();
       //     db.Database.EnsureCreated();
            db.Database.Migrate();
        }
    }
}
