using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Role
{
    public class DeleteRoleCommandHandler : CommandHandlerBase<DeleteRoleCommand>
    {
        private readonly IRepository<AspNetRole> _roleRepository;

        public DeleteRoleCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteRoleCommandValidator validator,
            IRepository<AspNetRole> roleRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _roleRepository = roleRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var role = await _roleRepository.GetByAsync(x => x.Id == request.Id);

            if (role != null)
            {
                role.IsActive = false;
                await _roleRepository.UpdateAsync(role);
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
