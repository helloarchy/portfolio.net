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
            
            const string workingsMarkdown = "### Workings v2.0\n## Created: Spring/Summer 2021\n\n## TL;DR\nThis project was a recreation of the original Workings web app. The original was a simple client only app, made in plain JavaScript. It made no use of any frameworks or libraries outside of JQuery. While a few new versions were attempted, using TypeScript, Node.js, and React, they were never completed. This latest version makes use of ASP.NET, C#, and Blazor. It also features a backend API, with an SQL database, to support full customisation for a registered and signed in user. The app, like the original Workings, provides a **paperwork** from which a traditional roman blind can be assembled. This paperwork includes the customer and client details, the cut lengths of fabrics and linings, and measurements for assembling the blind.\n\n## Aim\nProvide an automated paperwork generator.\n\n## Motivation\nDramatically simplify the process of calculating complex roman blind designs, including Cascade/Waterfall stacks, where each pleat has a varying length.\n\n## Requirements\nA full breakdown of the project requirements are:\n* Provide a printable A4 paperwork\n* Provide a simple form to fill out to generate the paperwork\n* Form\n    * Minimal\n        * Show no more fields than required\n        * Extend to show more fields where required";
            
            Project workings = new()
                {
                    Title = "Workings",
                    Created = DateTime.Now,
                    ShortDesc = "A web app to provide dynamically generated instructions for the" +
                                "creation of hand-made roman blinds.",
                    BodyMarkdown = workingsMarkdown,
                    Categories = workingsCategories,
                    ImageDescription = "A first picture of a cat",
                    ImageUrl = "https://cataas.com/cat/says/I'm%20First",
                    PageName = "workings",
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
                PageName = "second",
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
                PageName = "third",
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
                PageName = "fourth",
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
                PageName = "fifth",
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