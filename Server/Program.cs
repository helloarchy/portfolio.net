using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Portfolio.Server.Data;
using Portfolio.Shared;

namespace Portfolio.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            var sp = host.Services.GetService<IServiceScopeFactory>()
                ?.CreateScope()
                .ServiceProvider;
            var options = sp.GetRequiredService<DbContextOptions<PortfolioContext>>();
            await SeedDb(options, 5);

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
        
        private static async Task SeedDb(DbContextOptions<PortfolioContext> options, int count)
        {
            // empty to avoid logging while inserting (otherwise will flood console)
            var factory = new LoggerFactory();
            var builder = new DbContextOptionsBuilder<PortfolioContext>(options)
                .UseLoggerFactory(factory);

            await using var context = new PortfolioContext(builder.Options);
            // result is true if the database had to be created
            if (await context.Database.EnsureCreatedAsync())
            {
                var seed = new SeedProjects();
                await seed.SeedDbWithProjects(context, count);
            }
        }
    }
}
