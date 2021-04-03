using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Shared;

namespace Portfolio.Server.Data
{
    public class SeedProjects
    {
        
        private Project MakeProject()
        {
            var project = new Project
            {
                Title = "Lorem Ipsum"
            };
            return project;
        }
        
        public async Task SeedDbWithProjects(PortfolioContext context, int totalCount)
        {
            var count = 0;
            var currentCycle = 0;
            while (count < totalCount)
            {
                var list = new List<Project>();
                while (currentCycle++ < 100 && count++ < totalCount)
                {
                    list.Add(MakeProject());
                }
                if (list.Count > 0)
                {
                    await context.Projects.AddRangeAsync(list);
                    await context.SaveChangesAsync();
                }
                currentCycle = 0;
            }
        }
    }
}