using Columbia.Dsl;
using Columbia.Dsl.Utils;
using Columbia.DslPackage.CodeGenerators.Base;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Modeling.Shell;
using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Base
{
    internal abstract class CommandBase<TGenerator>  where TGenerator : CodeGeneratorBase, new()
    {
        protected abstract bool OverrideFile { get; }
        protected abstract prjBuildAction BuildAction { get; }
        protected CodeGeneratorBase Generator { get; } = new TGenerator();

        protected Dsl.Entity CurrentEntity { get; set; }
        protected ColumbiaCommandSet ColumbiaCommandSet { get; set; }

        public CommandBase(ColumbiaCommandSet columbiaCommandSet)
        {
            ColumbiaCommandSet = columbiaCommandSet;
        }
        protected abstract string GetFileName(Dsl.Entity entity);
        protected abstract string GetProject(DomainModel domainModel);

        public void OnStatusHandler(object sender, EventArgs e)
        {
            CheckEntitySelected(sender, e);
        }

        public void OnInvokeHandler(object sender, EventArgs e)
        {
            if (Generator == null) return;

            Generator.DomainModel = CurrentEntity.DomainModel;
            Generator.Entity = CurrentEntity;
            Generator.ClearBuffer();

            var code = Generator.TransformText();

            GenerateCodeFile(ColumbiaCommandSet.GetServiceProvider(), code);
        }

        private void CheckEntitySelected(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            command.Visible = command.Enabled = false;

            foreach (object selectedObject in ColumbiaCommandSet.GetCurrentSelection())
            {
                var entityShape = selectedObject as EntityShape;
                if (entityShape != null)
                {
                    command.Visible = true;

                    var entity = entityShape.ModelElement as Dsl.Entity;
                    if (entity != null)
                    {
                        command.Enabled = true;
                        CurrentEntity = entity;

                        return;
                    }
                }
            }
        }

        protected void GenerateCodeFile(IServiceProvider serviceProvider, string code)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (Generator.DomainModel == null) return;
            var projectName = GetProject(Generator.DomainModel);

            if (Generator.Entity == null) return;
            var fileName = GetFileName(Generator.Entity);
            if (string.IsNullOrWhiteSpace(fileName)) return;

            var dte = serviceProvider.GetService(typeof(DTE)) as DTE;
            if (dte == null) return;

            var targetProject = GetSolutionProject(dte, projectName);
            if (targetProject == null) return;

            var folderPath = Path.GetDirectoryName(targetProject.FullName);
            var fileGeneratedPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fileGeneratedPath))
            {
                if (OverrideFile) File.Delete(fileGeneratedPath);
                else return;
            }

            File.WriteAllText(fileGeneratedPath, code, Encoding.UTF8);

            var projectItem = targetProject.ProjectItems.AddFromFile(fileGeneratedPath);

            projectItem.Properties.Item("BuildAction").Value = BuildAction;
        }

        protected Project GetSolutionProject(DTE dte, string projectName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var solution = dte.Solution as Solution2;
            if (solution == null) return null;

            var projects = ProjectUtils.GetSolutionProjects(solution);
            if (projects == null) return null;

            return projects.FirstOrDefault(x =>
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                return x.Name == projectName;
            });
        }

        public DynamicStatusMenuCommand GetCommand(Guid menuGroup, int commandID)
        {
            return new DynamicStatusMenuCommand(
                new EventHandler(OnStatusHandler),
                new EventHandler(OnInvokeHandler),
                new CommandID(menuGroup, commandID)
            );
        }
    }
}
