using Portfolio.Server.Data;

namespace Portfolio.Server.Controllers
{
    public class ProjectController
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }
    }
}