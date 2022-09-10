using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using Columbia.DslPackage.CodeGenerators.Entity;
using Columbia.DslPackage.CustomCode.Commands.Base;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Entity
{
    internal class CreateEntityCommand : CommandBase
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;
        protected override CodeGeneratorBase Generator => EntityCodeGenerator;


        private EntityCodeGenerator EntityCodeGenerator = new EntityCodeGenerator();

        public CreateEntityCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Entity ?? string.Empty;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return $"{entity.Name}.cs";
        }
    }
}
