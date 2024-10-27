using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.MenuOption;
using $safesolutionname$.RestClient.Abstractions;
using $safesolutionname$.RestClient.Base;

namespace $safesolutionname$.RestClient.Implementation
{
    public class MenuOptionRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), IMenuOptionRestService
    {
        protected override string ApiController => "api/menuOption";

        public async Task<ResponseDto<GetMenuOptionDto>> Create(CreateMenuOptionDto createDto)
            => await Post<CreateMenuOptionDto, ResponseDto<GetMenuOptionDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetMenuOptionDto>> Update(UpdateMenuOptionDto updateDto)
            => await Put<UpdateMenuOptionDto, ResponseDto<GetMenuOptionDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete<ResponseDto>($"/{id}")!;

        public async Task<ResponseDto<GetMenuOptionDto>> Get(Guid id)
            => await Get<ResponseDto<GetMenuOptionDto>>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListMenuOptionDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListMenuOptionDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchMenuOptionDto>>> Search(SearchParamsDto<SearchMenuOptionFilterDto> filter)
            => await Post<SearchParamsDto<SearchMenuOptionFilterDto>, ResponseDto<SearchResultDto<SearchMenuOptionDto>>>("/search", filter)!;
    }
}
