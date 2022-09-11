﻿using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Base;
using Columbia.DslPackage.CodeGenerators.Dto.Templates;
using VSLangProj;

namespace Columbia.DslPackage.CustomCode.Commands.Dto
{
    internal class ListDtoFileGenerator : FileGeneratorBase<ListDtoCodeGenerator>
    {
        protected override bool OverrideFile => true;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Dto;
        }

        protected override string GetFileName(Dsl.Entity entity)
        {
            return entity != null ? $"{entity.Name}\\List{entity.Name}Dto.cs" : null;
        }
    }
}