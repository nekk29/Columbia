﻿using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Domain.FileGenerators;
using Columbia.DslPackage.CustomCode.Commands.Base;
using Columbia.DslPackage.CustomCode.Commands.Dto;
using Columbia.DslPackage.CustomCode.Commands.Entity;
using System;

namespace Columbia.DslPackage.CustomCode.Commands
{
    internal class GenerateQueriesCommand : CommandBase
    {
        public GenerateQueriesCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        public override void OnInvokeHandler(object sender, EventArgs e)
        {
            var serviceProvider = ColumbiaCommandSet.GetServiceProvider();

            #region Entity
            new CreateEntityFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            #endregion

            #region Dtos
            new DtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new CreateDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new UpdateDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new GetDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new ListDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new SearchDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new SearchFilterDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            #endregion

            #region Mapping
            new MappingProfileFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region Domain
            new GetQueryFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new GetQueryHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new ListQueryFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new ListQueryHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new SearchQueryFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new SearchQueryHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            #endregion
        }
    }
}
