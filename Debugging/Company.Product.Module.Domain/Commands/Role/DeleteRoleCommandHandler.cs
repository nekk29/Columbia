using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Role
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
