using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.Module;
using $safesolutionname$.Domain.Queries.Module;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;

namespace $safesolutionname$.Application
{
    public class ModuleApplication(IMediator mediator) : ApplicationBase(mediator), IModuleApplication
    {
        public async Task<ResponseDto<GetModuleDto>> Create(CreateModuleDto createDto)
            => await _mediator.Send(new CreateModuleCommand(createDto));

        public async Task<ResponseDto<GetModuleDto>> Update(UpdateModuleDto updateDto)
            => await _mediator.Send(new UpdateModuleCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteModuleCommand(id));

        public async Task<ResponseDto<GetModuleDto>> Get(Guid id)
            => await _mediator.Send(new GetModuleQuery(id));

        public async Task<ResponseDto<IEnumerable<ListModuleDto>>> List()
            => await _mediator.Send(new ListModuleQuery());

        public async Task<ResponseDto<IEnumerable<ListModuleDto>>> List(Guid applicationId)
            => await _mediator.Send(new ListModuleQuery(applicationId));

        public async Task<ResponseDto<IEnumerable<ListModuleDto>>> ListSimple(Guid applicationId)
            => await _mediator.Send(new ListModuleQuery(applicationId, false));

        public async Task<ResponseDto<SearchResultDto<SearchModuleDto>>> Search(SearchParamsDto<SearchModuleFilterDto> searchParams)
            => await _mediator.Send(new SearchModuleQuery(searchParams));
    }
}
