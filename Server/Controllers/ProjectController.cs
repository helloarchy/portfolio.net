using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Server.Data;
using Portfolio.Shared;

namespace Portfolio.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _context.Projects.ToList();
        }
    }
}