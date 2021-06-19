using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Portfolio.Shared
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = "Default";

        public virtual ICollection<Project> Projects { get; set; }

        public Category()
        {
            Projects = new HashSet<Project>();
        }
    }
}