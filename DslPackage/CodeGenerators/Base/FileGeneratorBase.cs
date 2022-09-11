using Columbia.Dsl;
using Columbia.Dsl.Utils;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.IO;
using System.Linq;
using System.Text;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Base
{
    internal abstract class FileGeneratorBase<TGenerator> where TGenerator : CodeGeneratorBase, new()
    {
        protected abstract bool OverrideFile { get; }
        protected abstract prjBuildAction BuildAction { get; }
        protected CodeGeneratorBase Generator { get; } = new TGenerator();

        protected abstract string GetFileName(Dsl.Entity entity);
        protected abstract string GetProject(DomainModel domainModel);

        public void GenerateFile(IServiceProvider serviceProvider, Dsl.Entity entity)
        {
            if (Generator == null) return;

            Generator.DomainModel = entity.DomainModel;
            Generator.Entity = entity;
            Generator.ClearBuffer();

            var code = Generator.TransformText();

            GenerateCodeFile(serviceProvider, code);
        }

        private void GenerateCodeFile(IServiceProvider serviceProvider, string code)
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

            if (fileName.Contains("\\"))
            {
                var index = 0;
                var currentFolder = folderPath;
                var fileNameParts = fileName.Split(char.Parse("\\"));

                for (var i = 0; i < fileNameParts.Length; i++)
                {
                    if (index == fileNameParts.Length - 1) break;

                    currentFolder = $"{currentFolder}\\{fileNameParts[i]}";

                    if (!Directory.Exists(currentFolder))
                        Directory.CreateDirectory(currentFolder);

                    index++;
                }
            }

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

        private Project GetSolutionProject(DTE dte, string projectName)
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
    }
}
