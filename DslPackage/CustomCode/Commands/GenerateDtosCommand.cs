using Columbia.Dsl;
using Columbia.DslPackage.CustomCode.Commands.Base;
using Columbia.DslPackage.CustomCode.Commands.Dto;
using System;

namespace Columbia.DslPackage.CustomCode.Commands
{
    internal class GenerateDtosCommand : CommandBase
    {
        public GenerateDtosCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        public override void OnInvokeHandler(object sender, EventArgs e)
        {
            var serviceProvider = ColumbiaCommandSet.GetServiceProvider();

            #region Dtos
            new DtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new CreateDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new UpdateDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new GetDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new ListDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new SearchDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            new SearchFilterDtoFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            #endregion
        }
    }
}
