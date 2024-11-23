using Columbia.Dsl;
using Microsoft.VisualStudio.Modeling.Shell;
using System;
using System.ComponentModel.Design;

namespace Columbia.DslPackage.CustomCode.Commands.Base
{
    internal abstract class CommandBase
    {
        protected Dsl.Entity CurrentEntity { get; set; }
        protected ColumbiaCommandSet ColumbiaCommandSet { get; set; }

        public CommandBase(ColumbiaCommandSet columbiaCommandSet)
        {
            ColumbiaCommandSet = columbiaCommandSet;
        }

        public void OnStatusHandler(object sender, EventArgs e)
        {
            CheckEntitySelected(sender, e);
        }

        public abstract void OnInvokeHandler(object sender, EventArgs e);

        private void CheckEntitySelected(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            command.Visible = command.Enabled = false;

            foreach (object selectedObject in ColumbiaCommandSet.GetCurrentSelection())
            {
                if (selectedObject is EntityShape entityShape)
                {
                    command.Visible = true;

                    if (entityShape.ModelElement is Dsl.Entity entity)
                    {
                        command.Enabled = true;
                        CurrentEntity = entity;

                        return;
                    }
                }
            }
        }

        public DynamicStatusMenuCommand GetCommand(Guid menuGroup, int commandID)
        {
            return new DynamicStatusMenuCommand(
                new EventHandler(OnStatusHandler),
                new EventHandler(OnInvokeHandler),
                new CommandID(menuGroup, commandID)
            );
        }
    }
}
