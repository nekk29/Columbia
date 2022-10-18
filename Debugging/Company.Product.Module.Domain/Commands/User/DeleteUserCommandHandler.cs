using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.User
{
    public class DeleteUserCommandHandler : CommandHandlerBase<DeleteUserCommand>
    {
        private readonly IRepository<Entity.AspNetUser> _userRepository;

        public DeleteUserCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteUserCommandValidator validator,
            IRepository<Entity.AspNetUser> userRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _userRepository = userRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var user = await _userRepository.GetByAsync(x => x.Id == request.Id);

            if (user != null)
            {
                user.IsActive = false;
                await _userRepository.UpdateAsync(user);
            }

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
