using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.RestClient.FileGenerators
{
    internal class RestServiceFileGenerator : FileGeneratorBase<RestServiceCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.RestClient;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"{entity.Name}Service.cs" : null;
        }
    }
}
