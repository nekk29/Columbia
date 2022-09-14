using Columbia.Dsl;
using Columbia.DslPackage.CustomCode.Commands.Base;
using Columbia.DslPackage.CustomCode.Commands.Entity;
using System;

namespace Columbia.DslPackage.CustomCode.Commands
{
    internal class GenerateEntityCommand : CommandBase
    {
        public GenerateEntityCommand(ColumbiaCommandSet columbiaCommandSet) : base(columbiaCommandSet)
        {

        }

        public override void OnInvokeHandler(object sender, EventArgs e)
        {
            var serviceProvider = ColumbiaCommandSet.GetServiceProvider();

            #region Entity
            new CreateEntityFileGenerator().GenerateFile(serviceProvider, CurrentEntity, true);
            #endregion
        }
    }
}
