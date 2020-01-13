using BlogSystem.Business.Implements;
using BlogSystem.Business.Interface;
using BlogSystem.DataAccess.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogSystem.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BlogContext>(opt =>
                opt.UseSqlite(Configuration
                    .GetConnectionString("BlogContext"), b => b.MigrationsAssembly("BlogSystem.Portal")));

            services.AddTransient<IBlogService, BlogService>();

            services.AddCors(option => option.AddPolicy("cors", policy =>
                policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new [] { "https://localhost:8088" })));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:8088");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}