using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.Setting
{
    public class DeleteSettingCommand(string group, string code) : CommandBase
    {
        public string Group { get; set; } = group;
        public string Code { get; set; } = code;
    }
}
