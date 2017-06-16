using System.Collections.Generic;
using ProjectManager.Framework.Data.Models;

namespace ProjectManager.Framework.Data
{
    public interface IDatabase
    {
        void AddProject(Project project);

        IList<Project> GetProjects();

        Project GetProjectById(int id);
    }
}
