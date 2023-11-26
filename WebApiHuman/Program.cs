using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHuman.Data;

namespace WebApiHuman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
               .MigrateDbContext<HumanContext>((context, services) =>
               {
                   //EnergyAnalizerSeed.SeedAsync(context);
               }).Run();

        }
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
      
    }
    public static class IWebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using IServiceScope serviceScope = webHost.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;
            ILogger<TContext> requiredService = serviceProvider.GetRequiredService<ILogger<TContext>>();
            TContext service = serviceProvider.GetService<TContext>();
            try
            {
                requiredService.LogInformation("Migrating database associated with context " + typeof(TContext).Name);
                service.Database.SetCommandTimeout(TimeSpan.FromSeconds(60.0));
                service.Database.Migrate();
                seeder(service, serviceProvider);
                requiredService.LogInformation("Migrated database associated with context " + typeof(TContext).Name);
                return webHost;
            }
            catch (Exception exception)
            {
                requiredService.LogError(exception, "An error occurred while migrating the database used on context " + typeof(TContext).Name);
                return webHost;
            }
        }
    }
}
