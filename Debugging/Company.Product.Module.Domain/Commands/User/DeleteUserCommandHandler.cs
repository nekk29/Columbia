using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.User
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
