using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.RestClient.FileGenerators
{
    internal class RestServiceAbstractionsFileGenerator : FileGeneratorBase<RestServiceAbstractionsCodeGenerator>
    {
        protected override bool OverwriteFile => false;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.RestClient;
        }

        protected override string GetFileName(Entity entity)
        {
            if (entity == null) return null;
            var module = !string.IsNullOrEmpty(entity.Module) ? entity.Module : entity.Name;
            return $"Abstractions\\I{module}RestService.cs";
        }
    }
}
