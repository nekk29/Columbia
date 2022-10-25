using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.MenuOption;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Application
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
