using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Shared;

namespace Portfolio.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            /*modelBuilder.Entity<Project>()
                .HasMany(p => p.Categories)
                .WithMany(pc => pc.Projects);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Technologies)
                .WithMany(pt => pt.Projects);*/
            
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Technology>().ToTable("Technologies");

            base.OnModelCreating(modelBuilder);
        }
    }
}
