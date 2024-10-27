using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class DeleteRoleCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteRoleCommandValidator validator,
        IRepository<AspNetRole> roleRepository
    ) : CommandHandlerBase<DeleteRoleCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var role = await roleRepository.GetByAsync(x => x.Id == request.Id);

            if (role != null)
            {
                await roleRepository.DeleteAsync(role);
                await roleRepository.SaveAsync();
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
