using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.Application;
using $safesolutionname$.Domain.Queries.Application;
using $safesolutionname$.Dto.Application;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Application
{
    public class ApplicationApplication(IMediator mediator) : ApplicationBase(mediator), IApplicationApplication
    {
        public async Task<ResponseDto<GetApplicationDto>> Create(CreateApplicationDto createDto)
            => await _mediator.Send(new CreateApplicationCommand(createDto));

        public async Task<ResponseDto<GetApplicationDto>> Update(UpdateApplicationDto updateDto)
            => await _mediator.Send(new UpdateApplicationCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteApplicationCommand(id));

        public async Task<ResponseDto<GetApplicationDto>> Get(Guid id)
            => await _mediator.Send(new GetApplicationQuery(id));

        public async Task<ResponseDto<IEnumerable<ListApplicationDto>>> List()
            => await _mediator.Send(new ListApplicationQuery());

        public async Task<ResponseDto<SearchResultDto<SearchApplicationDto>>> Search(SearchParamsDto<SearchApplicationFilterDto> searchParams)
            => await _mediator.Send(new SearchApplicationQuery(searchParams));
    }
}
