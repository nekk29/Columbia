﻿using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Module;
using $safesolutionname$.RestClient.Abstractions;
using $safesolutionname$.RestClient.Base;

namespace $safesolutionname$.RestClient.Implementation
{
    public class ModuleRestService(IServiceProvider serviceProvider) : BaseService(serviceProvider), IModuleRestService
    {
        protected override string ApiController => "api/module";

        public async Task<ResponseDto<GetModuleDto>> Create(CreateModuleDto createDto)
            => await Post<CreateModuleDto, ResponseDto<GetModuleDto>>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetModuleDto>> Update(UpdateModuleDto updateDto)
            => await Put<UpdateModuleDto, ResponseDto<GetModuleDto>>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(Guid id)
            => await Delete<ResponseDto>($"/{id}")!;

        public async Task<ResponseDto<GetModuleDto>> Get(Guid id)
            => await Get<ResponseDto<GetModuleDto>>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListModuleDto>>> List()
            => await Get<ResponseDto<IEnumerable<ListModuleDto>>>("/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchModuleDto>>> Search(SearchParamsDto<SearchModuleFilterDto> filter)
            => await Post<SearchParamsDto<SearchModuleFilterDto>, ResponseDto<SearchResultDto<SearchModuleDto>>>("/search", filter)!;
    }
}
