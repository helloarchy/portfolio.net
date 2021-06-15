using System;
using Portfolio.Shared;

namespace Portfolio.Client.Services
{
    public static class ProjectService
    {
        public static string GetTechnologyTitle(Technology technology)
        {
            return technology switch
            {
                Technology.Java => "Java",
                Technology.React => "React",
                Technology.CPlusPlus => "C++",
                Technology.CSharp => "C#",
                Technology.DotNet => ".NET",
                Technology.NextJs => "NEXTjs",
                Technology.NodeJs => "NODEjs",
                Technology.Unity => "Unity",
                _ => throw new Exception("Invalid technology")
            };
        }
    }
}