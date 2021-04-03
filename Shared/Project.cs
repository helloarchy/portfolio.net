using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared
{
    public class Project
    {
        public int ProjectId { get; set; } // Primary key
        public string Title { get; set; }
        
        public DateTime Created { get; set; }
        
        public string ShortDesc { get; set; }
    }
}