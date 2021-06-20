using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
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
        public async Task<IActionResult> GetAll()
        {
            var projects = await _context.Projects
                .Include(p => p.Categories)
                .Include(p => p.Technologies)
                .ToListAsync();

            return Ok(projects);
        }


        [HttpGet("{pageName:alpha}")]
        public async Task<IActionResult> Get(string pageName)
        {
            Debug.WriteLine("DEBUG => Backend: Fetching project...");
            var project = await _context.Projects
                .Include(p => p.Categories)
                .Include(p => p.Technologies)
                .FirstOrDefaultAsync(p => p.PageName == pageName);

            if (project is not null) return Ok(project);
            return NotFound();
        }
    }
}