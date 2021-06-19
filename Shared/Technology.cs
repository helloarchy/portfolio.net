using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared
{
    public class Technology
    {
        public int TechnologyId { get; set; }

        public string Name { get; set; } = "Default";

        public virtual ICollection<Project> Projects { get; set; }

        public Technology()
        {
            Projects = new HashSet<Project>();
        }
    }
}