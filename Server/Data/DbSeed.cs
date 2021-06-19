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
            Category[] categories =
            {
                new() {Name = "Data Science"},
                new() {Name = "Game Development"},
                new() {Name = "Software Development"},
                new() {Name = "Web Application"}
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }
        
        private static async Task SeedTechnologies(ApplicationDbContext context)
        {
            Technology[] technologies =
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
                new() {Name = "MongoDB"},
                new() {Name = "SQL"}
            };

            context.Technologies.AddRange(technologies);
            await context.SaveChangesAsync();
        }
        
        private static async Task SeedProjects(ApplicationDbContext context)
        {
            // Workings
            var workingsCategories = new List<Category>
            {
                context.Categories.FirstOrDefault(pc => pc.Name == "Web Application")
            };
            
            var workingsTechnologies = new List<Technology>
            {
                context.Technologies.FirstOrDefault(pt => pt.Name == "C#"),
                context.Technologies.FirstOrDefault(pt => pt.Name == ".NET"),
                context.Technologies.FirstOrDefault(pt => pt.Name == "SQL")
            };
            Project workings = new()
                {
                    Title = "Workings",
                    Created = DateTime.Now,
                    ShortDesc = "A web app to provide dynamically generated instructions for the" +
                                "creation of hand-made roman blinds.",
                    BodyMarkdown = "TODO",
                    Categories = workingsCategories,
                    ImageDescription = "A first picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20First",
                    Technologies = workingsTechnologies
                };

            Project project2 = new()
            {
                Title = "Some second project",
                Created = new DateTime(),
                ShortDesc = "Second lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                Categories = new List<Category>(),
                ImageDescription = "A second picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Second",
                Technologies = new List<Technology>()
            };

            var category1 = context.Categories.FirstOrDefault();
            var technology1 = context.Technologies.FirstOrDefault();
            
            project2.Categories.Add(category1);
            project2.Technologies.Add(technology1);
            
            Project project3 = new()
            {
                Title = "Perhaps a Third",
                Created = new DateTime(),
                ShortDesc = "Third lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                Categories = new List<Category>(),
                ImageDescription = "A third picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Third",
                Technologies = new List<Technology>()
            };
            
            project3.Categories.Add(category1);
            project3.Technologies.Add(technology1);
            
            Project project4 = new()
            {
                Title = "Oh, a Fourth?!",
                Created = new DateTime(),
                ShortDesc = "Fourth lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                Categories = new List<Category>(),
                ImageDescription = "A fourth picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Fourth",
                Technologies = new List<Technology>()
            };
            
            project4.Categories.Add(category1);
            project4.Technologies.Add(technology1);
            
            Project project5 = new()
            {
                Title = "Final Fifth",
                Created = new DateTime(),
                ShortDesc = "Fifth lorem ipsum dolor sit amet",
                BodyMarkdown = "",
                Categories = new List<Category>(),
                ImageDescription = "A fifth picture of a cat",
                ImageUrl = "https://cataas.com/cat/says/I'm%20Fifth",
                Technologies = new List<Technology>()
            };
            
            project5.Categories.Add(category1);
            project5.Technologies.Add(technology1);

            var projects = new List<Project>
            {
                workings,
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