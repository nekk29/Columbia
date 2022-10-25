using MediatR;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Application.Base;
using $safesolutionname$.Domain.Queries.Permission;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Permission;

namespace $safesolutionname$.Application
{
    public class PermissionApplication : ApplicationBase, IPermissionApplication
    {
        public PermissionApplication(IMediator mediator) : base(mediator)
        {

        }

        public async Task<ResponseDto<IEnumerable<ListPermissionDto>>> List()
            => await _mediator.Send(new ListPermissionQuery());
    }
}
