﻿using Microsoft.AspNetCore.Mvc;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Apis.Controllers
{
    [ApiController]
    [Security.Authorize]
    [Route("api/action")]
    public class ActionController(IActionApplication actionApplication)
    {
        [HttpPost]
        public async Task<ResponseDto<GetActionDto>> Create(CreateActionDto createDto)
            => await actionApplication.Create(createDto);

        [HttpPut]
        public async Task<ResponseDto<GetActionDto>> Update(UpdateActionDto updateDto)
            => await actionApplication.Update(updateDto);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(Guid id)
            => await actionApplication.Delete(id);

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetActionDto>> Get(Guid id)
            => await actionApplication.Get(id);

        [HttpGet("list")]
        public async Task<ResponseDto<IEnumerable<ListActionDto>>> List()
            => await actionApplication.List();

        [HttpGet("{moduleId}/list")]
        public async Task<ResponseDto<IEnumerable<ListActionDto>>> List(Guid moduleId)
            => await actionApplication.List(moduleId);

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchActionDto>>> Search(SearchParamsDto<SearchActionFilterDto> searchParams)
            => await actionApplication.Search(searchParams);
    }
}
