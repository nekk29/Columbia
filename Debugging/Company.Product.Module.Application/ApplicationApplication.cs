using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.Application;
using Company.Product.Module.Domain.Queries.Application;
using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;
using MediatR;

namespace Company.Product.Module.Application
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
