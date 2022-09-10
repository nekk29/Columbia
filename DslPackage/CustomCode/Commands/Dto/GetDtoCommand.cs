using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Dto;
using Columbia.DslPackage.CustomCode.Commands.Base;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Dto
{
    internal class GetDtoCommand : CommandBase<GetDtoCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        public GetDtoCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Entity ?? string.Empty;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return $"{entity.Name}/Get{entity.Name}Dto.cs";
        }
    }
}
