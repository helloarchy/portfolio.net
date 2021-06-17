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
            Project project =
                new()
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
            project.ProjectCategories.Add(category1);

            var technology1 = context.ProjectsTechnologies.FirstOrDefault();
            project.ProjectTechnologies.Add(technology1);
            
            /*new()
                {
                    Title = "Some second project",
                    Created = new DateTime(),
                    ShortDesc = "Second lorem ipsum dolor sit amet",
                    BodyMarkdown = "",
                    ProjectCategories = new List<ProjectCategory>
                    {
                        context.ProjectsCategories.FirstOrDefault(c => c.Name == "C#")
                    },
                    ImageDescription = "A second picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20Second",
                    ProjectTechnologies = new List<ProjectTechnology>
                    {
                        context.ProjectsTechnologies.FirstOrDefault(t => t.Name == "Web Applications")
                    }
                },
                new()
                {
                    Title = "Perhaps a Third",
                    Created = new DateTime(),
                    ShortDesc = "Third lorem ipsum dolor sit amet",
                    BodyMarkdown = "",
                    ProjectCategories = new List<ProjectCategory>
                    {
                        context.ProjectsCategories.FirstOrDefault(c => c.Name == "C#")
                    },
                    ImageDescription = "A third picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20Third",
                    ProjectTechnologies = new List<ProjectTechnology>
                    {
                        context.ProjectsTechnologies.FirstOrDefault(t => t.Name == "Web Applications")
                    }
                },
                new()
                {
                    Title = "Oh, a Fourth?!",
                    Created = new DateTime(),
                    ShortDesc = "Fourth lorem ipsum dolor sit amet",
                    BodyMarkdown = "",
                    ProjectCategories = new List<ProjectCategory>
                    {
                        context.ProjectsCategories.FirstOrDefault(c => c.Name == "C#")
                    },
                    ImageDescription = "A fourth picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20Fourth",
                    ProjectTechnologies = new List<ProjectTechnology>
                    {
                        context.ProjectsTechnologies.FirstOrDefault(t => t.Name == "Web Applications")
                    }
                },
                new()
                {
                    Title = "Final Fifth",
                    Created = new DateTime(),
                    ShortDesc = "Fifth lorem ipsum dolor sit amet",
                    BodyMarkdown = "",
                    ProjectCategories = new List<ProjectCategory>
                    {
                        context.ProjectsCategories.FirstOrDefault(c => c.Name == "C#")
                    },
                    ImageDescription = "A fifth picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20Fifth",
                    ProjectTechnologies = new List<ProjectTechnology>
                    {
                        context.ProjectsTechnologies.FirstOrDefault(t => t.Name == "Web Applications")
                    }
                }*/

            try
            {
                context.Projects.Add(project);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}