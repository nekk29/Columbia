using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.Setting;
using $safesolutionname$.Domain.Queries.Setting;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Application
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
