using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.Sample;
using Company.Product.Module.Domain.Queries.Sample;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;
using MediatR;

namespace Company.Product.Module.Application
{
    public class SampleApplication : ApplicationBase, ISampleApplication
    {
        public SampleApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetSampleDto>> Create(CreateSampleDto createDto)
            => await _mediator.Send(new CreateSampleCommand(createDto));

        public async Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto)
            => await _mediator.Send(new UpdateSampleCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteSampleCommand(id));

        public async Task<ResponseDto<GetSampleDto>> Get(Guid id)
            => await _mediator.Send(new GetSampleQuery(id));

        public async Task<ResponseDto<IEnumerable<ListSampleDto>>> List()
            => await _mediator.Send(new ListSampleQuery());

        public async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> searchParams)
            => await _mediator.Send(new SearchSampleQuery(searchParams));
    }
}
