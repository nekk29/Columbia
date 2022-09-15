using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Apis.FileGenerators;
using Columbia.DslPackage.CodeGenerators.Application.FileGenerators;
using Columbia.DslPackage.CodeGenerators.ApplicationAbstractions.FileGenerators;
using Columbia.DslPackage.CodeGenerators.Domain.FileGenerators;
using Columbia.DslPackage.CodeGenerators.RestClient.FileGenerators;
using Columbia.DslPackage.CustomCode.Commands.Base;
using Columbia.DslPackage.CustomCode.Commands.Dto;
using Columbia.DslPackage.CustomCode.Commands.Entity;
using System;

namespace Columbia.DslPackage.CustomCode.Commands
{
    internal class GenerateCrudCommand : CommandBase
    {
        public GenerateCrudCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
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
            new CreateCommandFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new CreateCommandHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new CreateCommandValidatorFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new DeleteCommandFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new DeleteCommandHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new DeleteCommandValidatorFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new UpdateCommandFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new UpdateCommandHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new UpdateCommandValidatorFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new GetQueryFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new GetQueryHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new ListQueryFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new ListQueryHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new SearchQueryFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new SearchQueryHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region Application
            new ApplicationFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region ApplicationAbstractions
            new ApplicationAbstractionsFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region Apis
            new ControllerFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region RestClient
            new RestServiceFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion
        }
    }
}
