using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.User
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
