using AutoMapper;
using BlogSystem.Business.Implements;
using BlogSystem.Business.Interface;
using BlogSystem.Business.AutoMapping;
using BlogSystem.DataAccess.DataContext;
using BlogSystem.DataAccess.Entities;
using BlogSystem.DataAccess.Repository;
using BlogSystem.Portal.Converts;
using BlogSystem.Portal.ExceptionHandleMiddleWare;
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
            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter()));

            services.AddDbContext<BlogContext>(opt =>
                opt.UseSqlite(Configuration
                    .GetConnectionString("BlogContext"), b => b.MigrationsAssembly("BlogSystem.Portal")));

            services.AddScoped<IRepository<BlogEntity>, BlogRepository<BlogEntity>>();

            services.AddTransient<IBlogService, BlogService>();

            services.AddCors(options =>
                options.AddPolicy("AllowMyOrigin", builder =>
                    builder.WithOrigins("http://localhost:8088").AllowAnyHeader().AllowAnyMethod()));

            services.AddSwaggerDocument();

            services.AddAutoMapper(c=>c.AddProfile<BlogEntityMapper>(), typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandle();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowMyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}