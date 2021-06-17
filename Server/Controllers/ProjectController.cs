using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Server.Data;
using Portfolio.Shared;

namespace Portfolio.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _context.Projects
                .Include(p => p.ProjectCategories)
                .Include(p => p.ProjectTechnologies)
                .ToListAsync();
            
            Console.WriteLine($"DEBUG => Projects are... length {projects.Count}");
            projects.ToList().ForEach(p =>
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine(p.Title);
                
                p.ProjectTechnologies.ToList().ForEach(pt =>
                {
                    Console.WriteLine(pt.Name);
                });
                
                p.ProjectCategories.ToList().ForEach(pc =>
                {
                    Console.WriteLine(pc.Name);
                });
            });            
            
            return Ok(projects);
        }
    }
}