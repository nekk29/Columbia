using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;

namespace Columbia.Wizard
{
    public class ProjectWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {

        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var safeSolutionName = SolutionWizard.GlobalDictionary["$safesolutionname$"] ?? string.Empty;
            var safeSolutionNameParts = safeSolutionName.Split('.');

            replacementsDictionary.Add("$safesolutionname$", safeSolutionName);
            replacementsDictionary.Add("$safesolutionname_lower$", safeSolutionName.ToLower());

            if (safeSolutionNameParts.Length == 1)
            {
                replacementsDictionary.Add("$safeproductname$", safeSolutionNameParts[0]);
                replacementsDictionary.Add("$safeproductname_lower$", safeSolutionNameParts[0].ToLower());
            }
            else if (safeSolutionNameParts.Length > 1)
            {
                replacementsDictionary.Add("$safeproductname$", safeSolutionNameParts[1]);
                replacementsDictionary.Add("$safeproductname_lower$", safeSolutionNameParts[1].ToLower());
            }
        }

        public bool ShouldAddProjectItem(string filePath) => true;
    }
}
