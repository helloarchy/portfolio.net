using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared
{
    public class ProjectTechnology
    {
        public int ProjectTechnologyId { get; set; }

        public string Name { get; set; } = "Default";

        public virtual ICollection<Project> Projects { get; set; }

        public ProjectTechnology()
        {
            Projects = new HashSet<Project>();
        }
    }
}