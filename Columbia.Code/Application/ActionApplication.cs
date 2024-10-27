﻿using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.Action;
using $safesolutionname$.Domain.Queries.Action;
using $safesolutionname$.Dto.Action;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Application
{
    public class ActionApplication(IMediator mediator) : ApplicationBase(mediator), IActionApplication
    {
        public async Task<ResponseDto<GetActionDto>> Create(CreateActionDto createDto)
            => await _mediator.Send(new CreateActionCommand(createDto));

        public async Task<ResponseDto<GetActionDto>> Update(UpdateActionDto updateDto)
            => await _mediator.Send(new UpdateActionCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteActionCommand(id));

        public async Task<ResponseDto<GetActionDto>> Get(Guid id)
            => await _mediator.Send(new GetActionQuery(id));

        public async Task<ResponseDto<IEnumerable<ListActionDto>>> List()
            => await _mediator.Send(new ListActionQuery());

        public async Task<ResponseDto<IEnumerable<ListActionDto>>> List(Guid moduleId)
            => await _mediator.Send(new ListActionQuery(moduleId));

        public async Task<ResponseDto<SearchResultDto<SearchActionDto>>> Search(SearchParamsDto<SearchActionFilterDto> searchParams)
            => await _mediator.Send(new SearchActionQuery(searchParams));
    }
}