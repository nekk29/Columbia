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
            replacementsDictionary.Add("$safesolutionname$", SolutionWizard.GlobalDictionary["$safesolutionname$"]);
            replacementsDictionary.Add("$safesolutionname_lower$", SolutionWizard.GlobalDictionary["$safesolutionname$"].ToLower());
        }

        public bool ShouldAddProjectItem(string filePath) => true;
    }
}
