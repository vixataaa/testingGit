using System.Collections.Generic;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Models;

namespace ProjectManager.Data
{
    public class Database : IDatabase
    {
        private readonly IList<Project> projects;

        public Database()
        {
            this.projects = new List<Project>();
        }

        public void AddProject(Project project)
        {
            this.projects.Add(project);
        }

        public Project GetProjectById(int id)
        {
            return this.projects[id];
        }

        public IList<Project> GetProjects()
        {
            return this.projects;
        }
    }
}
