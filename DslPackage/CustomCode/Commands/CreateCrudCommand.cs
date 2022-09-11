using Columbia.Dsl;
using Columbia.DslPackage.CustomCode.Commands.Base;
using Columbia.DslPackage.CustomCode.Commands.Dto;
using Columbia.DslPackage.CustomCode.Commands.Entity;
using System;

namespace Columbia.DslPackage.CustomCode.Commands
{
    internal class CreateCrudCommand : CommandBase
    {
        public CreateCrudCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        public override void OnInvokeHandler(object sender, EventArgs e)
        {
            var serviceProvider = ColumbiaCommandSet.GetServiceProvider();

            #region Entity
            new CreateEntityFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion

            #region Dtos
            new CreateDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new DtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new GetDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new ListDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new SearchDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new SearchFilterDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            new UpdateDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity);
            #endregion
        }
    }
}
