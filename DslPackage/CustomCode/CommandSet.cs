using Columbia.DslPackage.CustomCode.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Columbia.Dsl
{
    internal partial class ColumbiaCommandSet : ColumbiaCommandSetBase
    {
        private Guid columbiaCmdSetGuid = new Guid("479B2C12-8EF7-40D7-99C9-079C4171F91D");

        private const int generateCrudMenuCmd = 0x0200;
        private const int generateEntityMenuCmd = 0x0300;
        private const int generateDtosMenuCmd = 0x0400;
        private const int generateCommandsMenuCmd = 0x0500;
        private const int generateQueriesMenuCmd = 0x0600;

        protected override IList<MenuCommand> GetMenuCommands()
        {
            var commands = base.GetMenuCommands();

            var createCrudCommand = new GenerateCrudCommand(this);
            commands.Add(createCrudCommand.GetCommand(columbiaCmdSetGuid, generateCrudMenuCmd));

            var generateEntityCommand = new GenerateEntityCommand(this);
            commands.Add(generateEntityCommand.GetCommand(columbiaCmdSetGuid, generateEntityMenuCmd));

            var generateDtosCommand = new GenerateDtosCommand(this);
            commands.Add(generateDtosCommand.GetCommand(columbiaCmdSetGuid, generateDtosMenuCmd));

            var generateCommandsCommand = new GenerateCommandsCommand(this);
            commands.Add(generateCommandsCommand.GetCommand(columbiaCmdSetGuid, generateCommandsMenuCmd));

            var generateQueriesCommand = new GenerateQueriesCommand(this);
            commands.Add(generateQueriesCommand.GetCommand(columbiaCmdSetGuid, generateQueriesMenuCmd));

            return commands;
        }

        public System.Collections.ICollection GetCurrentSelection()
        {
            return CurrentSelection;
        }

        public IServiceProvider GetServiceProvider()
        {
            return ServiceProvider;
        }
    }
}
