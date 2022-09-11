using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Domain.FileGenerators
{
    internal class DeleteCommandFileGenerator : FileGeneratorBase<DeleteCommandCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Domain;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"Commands\\{entity.Name}\\Delete{entity.Name}Command.cs" : null;
        }
    }
}
