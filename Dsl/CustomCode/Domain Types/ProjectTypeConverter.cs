using Columbia.Dsl.CustomCode.DomainTypes.Base;
using Columbia.Dsl.Utils;
using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Columbia.Dsl.CustomCode.DomainTypes
{
    public class ProjectTypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var values = new List<string>();

            if (!(context.GetService(typeof(_DTE)) is _DTE dte))
                return new StandardValuesCollection(values);

            var solution = (Solution2)dte.Solution;
            if (solution == null)
                return new StandardValuesCollection(values);

            var projects = GetSolutionProjects(solution);

            values.AddRange(projects.Select(x => x.Name));

            values = values.OrderBy(x => x).ToList();

            return new StandardValuesCollection(values);
        }

        private static IEnumerable<Project> GetSolutionProjects(Solution2 solution)
        {
            var projects = new List<Project>();

            foreach (var proj in solution.Projects)
            {
                if (!(proj is Project project))
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
                if (!(projItem is ProjectItem projectItem))
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
