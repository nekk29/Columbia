using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Dto;
using Columbia.DslPackage.CustomCode.Commands.Base;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Dto
{
    internal class ListDtoCommand : CommandBase<ListDtoCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        public ListDtoCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Entity ?? string.Empty;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return $"{entity.Name}/List{entity.Name}Dto.cs";
        }
    }
}
