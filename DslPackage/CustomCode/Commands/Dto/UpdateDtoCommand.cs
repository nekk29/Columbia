using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Dto;
using Columbia.DslPackage.CustomCode.Commands.Base;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Dto
{
    internal class UpdateDtoCommand : CommandBase<UpdateDtoCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        public UpdateDtoCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Entity ?? string.Empty;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return $"{entity.Name}/Update{entity.Name}Dto.cs";
        }
    }
}
