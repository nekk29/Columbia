using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.MenuOption;
using $safesolutionname$.Domain.Queries.MenuOption;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;

namespace $safesolutionname$.Application
{
    public class MenuOptionApplication(IMediator mediator) : ApplicationBase(mediator), IMenuOptionApplication
    {
        public async Task<ResponseDto<GetMenuOptionDto>> Create(CreateMenuOptionDto createDto)
            => await _mediator.Send(new CreateMenuOptionCommand(createDto));

        public async Task<ResponseDto<GetMenuOptionDto>> Update(UpdateMenuOptionDto updateDto)
            => await _mediator.Send(new UpdateMenuOptionCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteMenuOptionCommand(id));

        public async Task<ResponseDto<GetMenuOptionDto>> Get(Guid id)
            => await _mediator.Send(new GetMenuOptionQuery(id));

        public async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List(string applicationCode)
            => await _mediator.Send(new ListMenuOptionQuery(applicationCode));

        public async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> ListAll(string applicationCode)
            => await _mediator.Send(new ListMenuOptionQuery(applicationCode, true));

        public async Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> Tree(string applicationCode)
            => await _mediator.Send(new TreeMenuOptionQuery(applicationCode));

        public async Task<ResponseDto<IEnumerable<TreeMenuOptionDto>>> TreeAll(string applicationCode)
            => await _mediator.Send(new TreeMenuOptionQuery(applicationCode, true));

        public async Task<ResponseDto<SearchResultDto<SearchMenuOptionDto>>> Search(SearchParamsDto<SearchMenuOptionFilterDto> searchParams)
            => await _mediator.Send(new SearchMenuOptionQuery(searchParams));
    }
}
