using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Apis.FileGenerators
{
    internal class ControllerFileGenerator : FileGeneratorBase<ControllerCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Apis;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"{entity.Name}Controller.cs" : null;
        }
    }
}
