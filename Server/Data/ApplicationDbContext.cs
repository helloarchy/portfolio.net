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
        public DbSet<ProjectCategory> ProjectsCategories { get; set; }
        public DbSet<ProjectTechnology> ProjectsTechnologies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            /*modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectCategories)
                .WithMany(pc => pc.Projects);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectTechnologies)
                .WithMany(pt => pt.Projects);
            
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<ProjectCategory>().ToTable("ProjectCategory");
            modelBuilder.Entity<ProjectTechnology>().ToTable("ProjectTechnology");*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
