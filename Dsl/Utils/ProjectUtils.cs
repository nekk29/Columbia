using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;

namespace Columbia.Dsl.Utils
{
    public class ProjectUtils
    {
        public static IEnumerable<Project> GetSolutionProjects(Solution2 solution)
        {
            var projects = new List<Project>();

            foreach (var proj in solution.Projects)
            {
                var project = proj as Project;
                if (project == null)
                    continue;

                if (project.Kind == Constants.vsProjectKindSolutionItems)
                {
                    projects.AddRange(GetSolutionFolderProjects(project));
                    continue;
                }

                if (project.Kind == CommonConstants.Projects.vsProjectKindMiscCSharp ||
                    project.Kind == CommonConstants.Projects.vsProjectKindMiscOther)
                    projects.Add(project);
            }

            return projects;
        }

        private static IEnumerable<Project> GetSolutionFolderProjects(Project solutionFolder)
        {
            var projects = new List<Project>();

            foreach (var projItem in solutionFolder.ProjectItems)
            {
                var projectItem = projItem as ProjectItem;
                if (projectItem == null)
                    continue;

                if (projectItem.Kind == Constants.vsProjectItemKindSolutionItems)
                {
                    var project = (projectItem.Object as Project);
                    if (project == null)
                        continue;

                    if (project.Kind == Constants.vsProjectKindSolutionItems)
                    {
                        projects.AddRange(GetSolutionFolderProjects(project));
                        continue;
                    }

                    if (project.Kind == CommonConstants.Projects.vsProjectKindMiscCSharp ||
                        project.Kind == CommonConstants.Projects.vsProjectKindMiscOther)
                        projects.Add(project);
                }
            }

            return projects;
        }
    }
}
