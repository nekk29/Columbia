using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class DeleteSettingCommand(string group, string code) : CommandBase
    {
        public string Group { get; set; } = group;
        public string Code { get; set; } = code;
    }
}
