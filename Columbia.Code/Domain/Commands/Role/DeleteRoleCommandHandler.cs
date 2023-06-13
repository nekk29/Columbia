using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Role
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
