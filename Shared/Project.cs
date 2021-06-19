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

        public string PageName { get; set; }
        public DateTime Created { get; set; }
        public string ShortDesc { get; set; }
        public string BodyMarkdown { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Technology> Technologies { get; set; } = new List<Technology>();
    }
}