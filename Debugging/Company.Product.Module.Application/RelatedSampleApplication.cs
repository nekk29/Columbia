using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.RelatedSample;
using Company.Product.Module.Domain.Queries.RelatedSample;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.RelatedSample;
using MediatR;

namespace Company.Product.Module.Application
{
    public class RelatedSampleApplication(IMediator mediator) : ApplicationBase(mediator), IRelatedSampleApplication
    {
        public async Task<ResponseDto<GetRelatedSampleDto>> Create(CreateRelatedSampleDto createDto)
            => await _mediator.Send(new CreateRelatedSampleCommand(createDto));

        public async Task<ResponseDto<GetRelatedSampleDto>> Update(UpdateRelatedSampleDto updateDto)
            => await _mediator.Send(new UpdateRelatedSampleCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteRelatedSampleCommand(id));

        public async Task<ResponseDto<GetRelatedSampleDto>> Get(Guid id)
            => await _mediator.Send(new GetRelatedSampleQuery(id));

        public async Task<ResponseDto<IEnumerable<ListRelatedSampleDto>>> List()
            => await _mediator.Send(new ListRelatedSampleQuery());

        public async Task<ResponseDto<SearchResultDto<SearchRelatedSampleDto>>> Search(SearchParamsDto<SearchRelatedSampleFilterDto> searchParams)
            => await _mediator.Send(new SearchRelatedSampleQuery(searchParams));
    }
}
