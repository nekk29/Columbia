using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.Setting;
using Company.Product.Module.Domain.Queries.Setting;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using MediatR;

namespace Company.Product.Module.Application
{
    public class SettingApplication(IMediator mediator) : ApplicationBase(mediator), ISettingApplication
    {
        public async Task<ResponseDto<GetSettingDto>> Create(CreateSettingDto createDto)
            => await _mediator.Send(new CreateSettingCommand(createDto));

        public async Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto)
            => await _mediator.Send(new UpdateSettingCommand(updateDto));

        public async Task<ResponseDto> Delete(string group, string code)
            => await _mediator.Send(new DeleteSettingCommand(group, code));

        public async Task<ResponseDto<GetSettingDto>> Get(string group, string code)
            => await _mediator.Send(new GetSettingQuery(group, code));

        public async Task<ResponseDto<IEnumerable<ListSettingDto>>> List()
            => await _mediator.Send(new ListSettingQuery());

        public async Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams)
            => await _mediator.Send(new SearchSettingQuery(searchParams));
    }
}
