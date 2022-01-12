using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SportResults.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportResults
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .MigrateDatabase<Models.SportContext>()
                .Run();
        }

        
        //public static void Main(string[] args)
        //{
        //    var host = BuildWebHost(args);

        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;

        //        try
        //        {
        //            var context = services.GetService<SportResults.Models.SportContext>();
        //            context.Database.Migrate();
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = services.GetRequiredService<ILogger<Program>>();
        //            logger.LogError(ex, "An error occured seeding the DB.");
        //        }
        //    }

        //    host.Run();
        //}

        //private static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
    }
}
