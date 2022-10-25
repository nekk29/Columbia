using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Application.Base;
using Company.Product.Module.Domain.Queries.Permission;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Permission;
using MediatR;

namespace Company.Product.Module.Application
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
