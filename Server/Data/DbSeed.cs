using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared;

namespace Portfolio.Server.Data
{
    public class DbSeed
    {
        public static async Task Initialise(ApplicationDbContext context)
        {
            // Look for any blind profiles.
            if (context.Projects.Any())
            {
                Console.WriteLine("DB has already been seeded!");
                return; // DB has been seeded
            }

            await SeedCategories(context);
            await SeedTechnologies(context);
            await SeedProjects(context);
        }

        private static async Task SeedCategories(ApplicationDbContext context)
        {
            ProjectCategory[] categories =
            {
                new() {Name = "Data Science"},
                new() {Name = "Game Development"},
                new() {Name = "Software Development"},
                new() {Name = "Web Application"}
            };

            context.ProjectsCategories.AddRange(categories);
            await context.SaveChangesAsync();
        }
        
        private static async Task SeedTechnologies(ApplicationDbContext context)
        {
            ProjectTechnology[] technologies =
            {
                new() {Name = "C++"},
                new() {Name = "C#"},
                new() {Name = ".NET"},
                new() {Name = "Next.js"},
                new() {Name = "Node.js"},
                new() {Name = "Java"},
                new() {Name = "React"},
                new() {Name = "Unity"},
                new() {Name = "TypeScript"},
                new() {Name = "JavaScript"},
                new() {Name = "PHP"},
                new() {Name = "MongoDB"}
            };

            context.ProjectsTechnologies.AddRange(technologies);
            await context.SaveChangesAsync();
        }
        
        private static async Task SeedProjects(ApplicationDbContext context)
        {
            Project project1 = new()
                {
                    Title = "The First Project",
                    Created = DateTime.Now,
                    ShortDesc = "First lorem ipsum dolor sit amet",
                    BodyMarkdown = "TODO",
                    ProjectCategories = new List<ProjectCategory>(),
                    ImageDescription = "A first picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20First",
                    ProjectTechnologies = new List<ProjectTechnology>()
                };

            var category1 = context.ProjectsCategories.FirstOrDefault();
            var technology1 = context.ProjectsTechnologies.FirstOrDefault();
            
            project1.ProjectCategories.Add(category1);
            project1.ProjectTechnologies.Add(technology1);

            Project project2 = new()
            {
                Title = "Some second project",
                Created = new DateTime(),
                ShortDesc = "Second lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                ProjectCategories = new List<ProjectCategory>(),
                ImageDescription = "A second picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Second",
                ProjectTechnologies = new List<ProjectTechnology>()
            };
            
            project2.ProjectCategories.Add(category1);
            project2.ProjectTechnologies.Add(technology1);
            
            Project project3 = new()
            {
                Title = "Perhaps a Third",
                Created = new DateTime(),
                ShortDesc = "Third lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                ProjectCategories = new List<ProjectCategory>(),
                ImageDescription = "A third picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Third",
                ProjectTechnologies = new List<ProjectTechnology>()
            };
            
            project3.ProjectCategories.Add(category1);
            project3.ProjectTechnologies.Add(technology1);
            
            Project project4 = new()
            {
                Title = "Oh, a Fourth?!",
                Created = new DateTime(),
                ShortDesc = "Fourth lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                ProjectCategories = new List<ProjectCategory>(),
                ImageDescription = "A fourth picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Fourth",
                ProjectTechnologies = new List<ProjectTechnology>()
            };
            
            project4.ProjectCategories.Add(category1);
            project4.ProjectTechnologies.Add(technology1);
            
            Project project5 = new()
            {
                Title = "Final Fifth",
                Created = new DateTime(),
                ShortDesc = "Fifth lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                ProjectCategories = new List<ProjectCategory>(),
                ImageDescription = "A fifth picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Fifth",
                ProjectTechnologies = new List<ProjectTechnology>()
            };
            
            project5.ProjectCategories.Add(category1);
            project5.ProjectTechnologies.Add(technology1);

            var projects = new List<Project>
            {
                project1,
                project2,
                project3,
                project4,
                project5
            };
            
            try
            {
                context.Projects.AddRange(projects);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}