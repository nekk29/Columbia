using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.MenuOption
{
    public class DeleteMenuOptionCommand(Guid id) : CommandBase
    {
        public Guid Id { get; set; } = id;
    }
}
