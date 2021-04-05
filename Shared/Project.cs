using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared
{
    public class Project
    {
        public int ProjectId { get; set; } // Primary key
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string ShortDesc { get; set; }
        public string BodyMarkdown { get; set; }
        public List<Category> Categories { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public List<Technology> Technologies { get; set; }
    }

    public enum Category
    {
        DataScience,
        GameDevelopment,
        SoftwareDevelopment ,
        WebApplications,
    }

    public enum Technology
    {
        CPlusPlus,
        CSharp,
        DotNet,
        NextJs,
        NodeJs,
        Java,
        React,
        Unity,
    }
}