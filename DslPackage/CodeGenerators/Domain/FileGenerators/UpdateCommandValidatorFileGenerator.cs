using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Domain.FileGenerators
{
    internal class UpdateCommandValidatorFileGenerator : FileGeneratorBase<UpdateCommandValidatorCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Domain;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"Commands\\{entity.Name}\\Update{entity.Name}CommandValidator.cs" : null;
        }
    }
}
