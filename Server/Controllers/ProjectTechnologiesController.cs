using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Server.Data;
using Portfolio.Shared;

namespace Portfolio.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectTechnologiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projectTechnologies = await _context.ProjectsTechnologies
                .ToListAsync();
            
            return Ok(projectTechnologies);
        }
    }
}