using AutoMapper;
using MediatR;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Command.Permission
{
    public class AssignPermissionsCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        AssignPermissionsCommandValidator validator,
        IRepository<Entity.Permission> permissionRepository,
        IRepository<Entity.AspNetRole> aspNetRoleRepository
    ) : CommandHandlerBase<AssignPermissionsCommand>(unitOfWork, mapper, mediator, validator)
    {
        public override async Task<ResponseDto> HandleCommand(AssignPermissionsCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();

            var role = await aspNetRoleRepository.GetByAsNoTrackingAsync(x => x.Id == request.RoleId);
            if (role == null)
                return response;

            var permissions = await permissionRepository.FindByAsNoTrackingAsync(
                x => x.RoleId == role.Id && x.IsActive
            );

            var uniqueActionIds = request.ActionIds.Distinct();
            var permissionsActionIds = permissions.Select(x => x.ActionId);
            var permissionsToDelete = permissions.Where(x => !uniqueActionIds.Contains(x.ActionId));

            await permissionRepository.DeleteAsync(permissionsToDelete.ToArray());

            var permissionsActionIdsToAdd = uniqueActionIds.Where(x => !permissionsActionIds.Contains(x));
            var permissionsActionToAdd = permissionsActionIdsToAdd.Select(x => new Entity.Permission
            {
                RoleId = request.RoleId,
                ActionId = x
            });

            await permissionRepository.AddAsync(permissionsActionToAdd.ToArray());

            response.AddOkResult(Resources.Permission.AssignPermissionsSuccess);

            return response;
        }
    }
}
