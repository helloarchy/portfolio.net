using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Shared;

namespace Portfolio.Server.Data
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Use secrets here...
            optionsBuilder.UseNpgsql("Host=localhost;Database=portfolio;Username=postgres;Password=Password123!");
        }

        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }
    }
}
