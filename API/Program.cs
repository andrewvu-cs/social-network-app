using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        // Where .NET looks for our Main method which executes our app
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
