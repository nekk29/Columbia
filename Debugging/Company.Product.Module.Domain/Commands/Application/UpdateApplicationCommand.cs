using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Application;

namespace Company.Product.Module.Domain.Commands.Application
{
    public class UpdateApplicationCommand(UpdateApplicationDto updateDto) : CommandBase<GetApplicationDto>
    {
        public UpdateApplicationDto UpdateDto { get; set; } = updateDto;
    }
}
