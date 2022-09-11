using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using Columbia.DslPackage.CodeGenerators.Entity.Templates;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Entity
{
    internal class CreateEntityFileGenerator : FileGeneratorBase<EntityCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Entity ?? string.Empty;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"{entity.Name}.cs" : null;
        }
    }
}
