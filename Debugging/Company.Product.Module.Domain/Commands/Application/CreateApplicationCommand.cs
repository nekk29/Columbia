using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Application;

namespace Company.Product.Module.Domain.Commands.Application
{
    public class CreateApplicationCommand(CreateApplicationDto createDto) : CommandBase<GetApplicationDto>
    {
        public CreateApplicationDto CreateDto { get; set; } = createDto;
    }
}
