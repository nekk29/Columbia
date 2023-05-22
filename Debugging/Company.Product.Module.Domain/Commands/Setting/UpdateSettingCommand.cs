using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Commands.Setting
{
    public class UpdateSettingCommand : CommandBase<GetSettingDto>
    {
        public UpdateSettingCommand(UpdateSettingDto updateDto) => UpdateDto = updateDto;
        public UpdateSettingDto UpdateDto { get; set; }
    }
}
