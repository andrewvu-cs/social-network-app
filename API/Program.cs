using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        // Where .NET looks for our Main method which executes our app
        public static void Main(string[] args)
        {
            // we want to get a ref to our DbContext
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    // Every time we start our app, we will check to see if there is an avail db,
                    // if not were going to create a new one
                    context.Database.Migrate();
                    Seed.SeedData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred during migration");
                };
            }

            host.Run();
        }

        // Program initialization abstraction
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Additional configuration
                    webBuilder.UseStartup<Startup>();
                });
    }
}
