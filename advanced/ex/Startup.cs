

namespace ex
{
    using ex.Configuration;
    using ex.Data;
    using ex.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();
            services.AddControllersWithViews();
            services.AddMvc();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                   );
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
