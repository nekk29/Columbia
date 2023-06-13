using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Commands.Role;
using $safesolutionname$.Domain.Queries.Role;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Role;

namespace $safesolutionname$.Application
{
    public class RoleApplication : ApplicationBase, IRoleApplication
    {
        public RoleApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<GetRoleDto>> Create(CreateRoleDto createDto)
            => await _mediator.Send(new CreateRoleCommand(createDto));

        public async Task<ResponseDto<GetRoleDto>> Update(UpdateRoleDto updateDto)
            => await _mediator.Send(new UpdateRoleCommand(updateDto));

        public async Task<ResponseDto> Delete(Guid id)
            => await _mediator.Send(new DeleteRoleCommand(id));

        public async Task<ResponseDto<GetRoleDto>> Get(Guid id)
            => await _mediator.Send(new GetRoleQuery(id));

        public async Task<ResponseDto<IEnumerable<ListRoleDto>>> List()
            => await _mediator.Send(new ListRoleQuery());

        public async Task<ResponseDto<SearchResultDto<SearchRoleDto>>> Search(SearchParamsDto<SearchRoleFilterDto> searchParams)
            => await _mediator.Send(new SearchRoleQuery(searchParams));
    }
}
