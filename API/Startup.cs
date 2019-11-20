using Application.Activities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Dependency injection container, once available in here they can be used in other areas
        public void ConfigureServices(IServiceCollection services)
        {
            // Make our DataContext info accessible throuohout our entire project
            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            // APIs have endpoints and once they are called, our controllers will execute the business logic
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Add middleware, ordering is important
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // I do not want to be redirected to https when 
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
