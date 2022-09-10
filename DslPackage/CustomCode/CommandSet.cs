using Columbia.DslPackage.CustomCode.Commands.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Columbia.Dsl
{
    internal partial class ColumbiaCommandSet : ColumbiaCommandSetBase
    {
        private Guid columbiaCmdSetGuid = new Guid("479B2C12-8EF7-40D7-99C9-079C4171F91D");

        private const int createEntityMenuCmd = 0x0200;

        protected override IList<MenuCommand> GetMenuCommands()
        {
            var commands = base.GetMenuCommands();

            var createEntityCommand = new CreateEntityCommand(this);
            commands.Add(createEntityCommand.GetCommand(columbiaCmdSetGuid, createEntityMenuCmd));

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
