using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Dto
{
    internal class SearchFilterDtoFileGenerator : FileGeneratorBase<SearchFilterDtoCodeGenerator>
    {
        protected override bool OverwriteFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Dto;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            if (entity == null) return null;
            var module = !string.IsNullOrEmpty(entity.Module) ? entity.Module : entity.Name;
            return $"{module}\\Search{entity.Name}FilterDto.cs";
        }
    }
}
