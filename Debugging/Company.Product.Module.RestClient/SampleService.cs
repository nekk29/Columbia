﻿using Company.Product.Module.RestClient.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Sample;

namespace Company.Product.Module.RestClient
{
    public class SampleService : BaseService
    {
        protected override string ApiController => "api/sample";

        public SampleService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetSampleDto>> Insert(CreateSampleDto createDto)
            => await Post<CreateSampleDto, GetSampleDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetSampleDto>> Update(UpdateSampleDto updateDto)
            => await Put<UpdateSampleDto, GetSampleDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetSampleDto>> Get(int id)
            => await Get<GetSampleDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListSampleDto>>> List()
            => await Get<IEnumerable<ListSampleDto>>("list")!;

        public async Task<ResponseDto<SearchResultDto<SearchSampleDto>>> Search(SearchParamsDto<SearchSampleFilterDto> filter)
            => await Post<SearchParamsDto<SearchSampleFilterDto>, SearchResultDto<SearchSampleDto>>("/search", filter)!;
    }
}
