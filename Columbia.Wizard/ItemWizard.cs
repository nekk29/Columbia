using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;

namespace Columbia.Wizard
{
    public class ItemWizard : IWizard
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
            var dte = automationObject as _DTE;
            var safesolutionname = string.Empty;
            var solution = (Solution2)dte.Solution;

            if (File.Exists(solution.FileName))
            {
                var solutionFileInfo = new FileInfo(solution.FileName);
                safesolutionname = solutionFileInfo.Name.Replace(".sln", string.Empty);
            }

            replacementsDictionary.Add("$safesolutionname$", safesolutionname);
        }

        public bool ShouldAddProjectItem(string filePath) => true;
    }
}
