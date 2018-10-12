using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using EnvironmentCrime_4.Models;
using Microsoft.AspNetCore;

namespace EnvironmentCrime_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //            BuildWebHost(args).Run();

            IWebHost host = CreateWebHostBuilder(args).Build();
            
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DBInitializer.EnsurePopulated(context);
                }
                catch(Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occured while initializing the database");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
