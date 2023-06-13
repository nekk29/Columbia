using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Commands.Role;
using Company.Product.Module.Domain.Queries.Role;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Role;
using MediatR;

namespace Company.Product.Module.Application
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
