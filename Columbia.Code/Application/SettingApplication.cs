using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.Setting;
using $safesolutionname$.Domain.Queries.Setting;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Application
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
