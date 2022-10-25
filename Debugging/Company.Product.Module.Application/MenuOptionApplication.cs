using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.MenuOption;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.MenuOption;
using MediatR;

namespace Company.Product.Module.Application
{
    public class MenuOptionApplication : ApplicationBase, IMenuOptionApplication
    {
        public MenuOptionApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List()
            => await _mediator.Send(new ListMenuOptionsQuery());

        public async Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> Tree()
            => await _mediator.Send(new TreeMenuOptionsQuery());
    }
}
