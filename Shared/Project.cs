using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Shared
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string ShortDesc { get; set; }
        public string BodyMarkdown { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<ProjectCategory> ProjectCategories { get; set; }
        public virtual ICollection<ProjectTechnology> ProjectTechnologies { get; set; }

        public Project()
        {
            ProjectCategories = new HashSet<ProjectCategory>();
            ProjectTechnologies = new HashSet<ProjectTechnology>();
        }
    }
}