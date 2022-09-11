using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Application.FileGenerators
{
    internal class ApplicationFileGenerator : FileGeneratorBase<ApplicationCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Application;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"{entity.Name}Application.cs" : null;
        }
    }
}
