using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BlogSystem.DataAccess.DataContext;
using BlogSystem.Business.Interface;
using BlogSystem.Business.Implements;


namespace BlogSystem.Portal
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers ();
            services.AddDbContext<BlogContext>(opt => 
            opt.UseSqlite(Configuration
                    .GetConnectionString("BlogContext"), b => b.MigrationsAssembly("BlogSystem.Portal")));

            services.AddTransient<IBlogService, BlogService>();
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints =>
            {
                endpoints.MapControllers ();
            });
        }
    }
}