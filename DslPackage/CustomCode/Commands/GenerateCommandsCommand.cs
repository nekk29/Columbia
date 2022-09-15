using Columbia.Dsl;
using Columbia.DslPackage.CodeGenerators.Domain.FileGenerators;
using Columbia.DslPackage.CustomCode.Commands.Base;
using Columbia.DslPackage.CustomCode.Commands.Dto;
using Columbia.DslPackage.CustomCode.Commands.Entity;
using System;

namespace Columbia.DslPackage.CustomCode.Commands
{
    internal class GenerateCommandsCommand : CommandBase
    {
        public GenerateCommandsCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
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
            #endregion

            #region Mapping
            new MappingProfileFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region Commands
            new CreateCommandFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new CreateCommandHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new CreateCommandValidatorFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new DeleteCommandFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new DeleteCommandHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new DeleteCommandValidatorFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new UpdateCommandFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new UpdateCommandHandlerFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new UpdateCommandValidatorFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            #endregion
        }
    }
}
