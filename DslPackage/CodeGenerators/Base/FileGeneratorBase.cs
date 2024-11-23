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
        protected abstract bool OverwriteFile { get; }
        protected abstract prjBuildAction BuildAction { get; }
        protected CodeGeneratorBase Generator { get; } = new TGenerator();

        protected abstract string GetFileName(Dsl.Entity entity);
        protected abstract string GetProject(DomainModel domainModel);

        public void GenerateFile(IServiceProvider serviceProvider, Dsl.Entity entity, bool? overwriteFile = null)
        {
            if (Generator == null) return;

            Generator.DomainModel = entity.DomainModel;
            Generator.Entity = entity;
            Generator.ClearBuffer();

            var code = Generator.TransformText();

            GenerateCodeFile(serviceProvider, code, overwriteFile);
        }

        private void GenerateCodeFile(IServiceProvider serviceProvider, string code, bool? overwriteFile = null)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (Generator.DomainModel == null) return;
            var projectName = GetProject(Generator.DomainModel);

            if (Generator.Entity == null) return;
            var fileName = GetFileName(Generator.Entity);
            if (string.IsNullOrWhiteSpace(fileName)) return;

            if (!(serviceProvider.GetService(typeof(DTE)) is DTE dte)) return;

            var targetProject = GetSolutionProject(dte, projectName);
            if (targetProject == null) return;

            var overwrite = overwriteFile ?? OverwriteFile;
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
                if (overwrite) File.Delete(fileGeneratedPath);
                else return;
            }

            File.WriteAllText(fileGeneratedPath, code, Encoding.UTF8);

            var projectItem = targetProject.ProjectItems.AddFromFile(fileGeneratedPath);

            projectItem.Properties.Item("BuildAction").Value = BuildAction;
        }

        private Project GetSolutionProject(DTE dte, string projectName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (!(dte.Solution is Solution2 solution)) return null;

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
