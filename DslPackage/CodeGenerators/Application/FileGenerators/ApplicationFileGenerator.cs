using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Application.FileGenerators
{
    internal class ApplicationFileGenerator : FileGeneratorBase<ApplicationCodeGenerator>
    {
        protected override bool OverwriteFile => false;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Application;
        }

        protected override string GetFileName(Entity entity)
        {
            if (entity == null) return null;
            var module = !string.IsNullOrEmpty(entity.Module) ? entity.Module : entity.Name;
            return $"{module}Application.cs";
        }
    }
}
