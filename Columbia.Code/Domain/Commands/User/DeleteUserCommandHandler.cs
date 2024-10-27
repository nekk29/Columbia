using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.User
{
    public class DeleteUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteUserCommandValidator validator,
        IRepository<Entity.AspNetUser> userRepository
    ) : CommandHandlerBase<DeleteUserCommand>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto> HandleCommand(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var user = await userRepository.GetByAsync(x => x.Id == request.Id);

            if (user != null)
            {
                await userRepository.DeleteAsync(user);
                await userRepository.SaveAsync();
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
