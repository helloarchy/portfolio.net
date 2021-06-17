using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Portfolio.Shared
{
    public class ProjectCategory
    {
        public int ProjectCategoryId { get; set; }

        public string Name { get; set; } = "Default";

        public virtual ICollection<Project> Projects { get; set; }

        public ProjectCategory()
        {
            Projects = new HashSet<Project>();
        }
    }
}