
namespace evnServer
{
using evnServer.Config;
using evnServer.Data;
using evnServer.Data.Repositories;
using evnServer.Validation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
      //          configuration.RootPath = "ClientApp/dist";
            });

            services.AddFluentValidation(config => {
                config.AutomaticValidationEnabled = true;
                config.DisableDataAnnotationsValidation = true;
                config.ImplicitlyValidateChildProperties = true;
                config.ImplicitlyValidateRootCollectionElements = true;
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddMediatR(typeof(Startup));

            services.AddTransient<UserCreatDtoValidation>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "evnServer", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabse();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "evnServer v1"));
            }

            app.UseHttpsRedirection()
                .UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors(options => options
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());


            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

          //  app.UseSpa(spa =>
          //  {
              
          //     // spa.Options.SourcePath = "ClientApp";

          //      if (env.IsDevelopment())
          //      {
          ////        spa.UseAngularCliServer(npmScript: "start");
          //      }
          //  });
        }
    }
}
