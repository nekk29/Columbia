using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.Setting;
using Company.Product.Module.Domain.Queries.Setting;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using MediatR;

namespace Company.Product.Module.Application
{
    public class SettingApplication : ApplicationBase, ISettingApplication
    {
        public SettingApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetSettingDto>> Update(UpdateSettingDto updateDto)
            => await _mediator.Send(new UpdateSettingCommand(updateDto));

        public async Task<ResponseDto<GetSettingDto>> Get(string group, string code)
            => await _mediator.Send(new GetSettingQuery(group, code));

        public async Task<ResponseDto<SearchResultDto<SearchSettingDto>>> Search(SearchParamsDto<SearchSettingFilterDto> searchParams)
            => await _mediator.Send(new SearchSettingQuery(searchParams));
    }
}
