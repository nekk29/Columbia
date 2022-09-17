using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;

namespace Columbia.Wizard
{
    public class SolutionWizard : IWizard
    {
        public static string SolutionFullName;

        public static Dictionary<string, string> GlobalDictionary = new Dictionary<string, string>();

        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {
            if (string.IsNullOrEmpty(SolutionFullName)) return;
            if (!Directory.Exists(SolutionFullName)) return;

            File.Copy(".gitattributes", $"{SolutionFullName}\\.gitattributes");
            File.Copy(".gitignore", $"{SolutionFullName}\\.gitignore");
            File.Copy("README.md", $"{SolutionFullName}\\README.md");
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
            var solution = (Solution2)dte.Solution;

            if (solution != null)
                SolutionFullName = solution.FullName;

            GlobalDictionary["$safesolutionname$"] = replacementsDictionary["$safeprojectname$"];
        }

        public bool ShouldAddProjectItem(string filePath) => true;
    }
}
