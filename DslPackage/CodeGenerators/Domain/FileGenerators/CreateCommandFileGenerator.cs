﻿using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators;
using Columbia.DslPackage.CodeGenerators.Base;
using VSLangProj;

namespace Columbia.DslPackage.CodeGenerators.Domain.FileGenerators
{
    internal class CreateCommandFileGenerator : FileGeneratorBase<CreateCommandCodeGenerator>
    {
        protected override bool OverrideFile => false;
        protected override prjBuildAction BuildAction => prjBuildAction.prjBuildActionCompile;

        protected override string GetProject(DomainModel domainModel)
        {
            return domainModel?.Domain;
        }

        protected override string GetFileName(Entity entity)
        {
            return entity != null ? $"Commands\\{entity.Name}\\Create{entity.Name}Command.cs" : null;
        }
    }
}
