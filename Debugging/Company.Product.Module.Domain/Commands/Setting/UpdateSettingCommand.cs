using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Commands.Setting
{
    public class UpdateSettingCommand(UpdateSettingDto updateDto) : CommandBase<GetSettingDto>
    {
        public UpdateSettingDto UpdateDto { get; set; } = updateDto;
    }
}
