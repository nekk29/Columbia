using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.ApplicationAbstractions.FileGenerators
{
    internal class ApplicationAbstractionsFileGenerator : FileGeneratorBase<ApplicationAbstractionsCodeGenerator>
    {
        protected override bool OverwriteFile => false;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.ApplicationAbstractions;
        }

        protected override string GetFileName(Entity entity)
        {
            if (entity == null) return null;
            var module = !string.IsNullOrEmpty(entity.Module) ? entity.Module : entity.Name;
            return $"I{module}Application.cs";
        }
    }
}
