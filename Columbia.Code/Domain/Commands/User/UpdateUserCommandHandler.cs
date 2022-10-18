using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.User
{
    public class UpdateUserCommandHandler : CommandHandlerBase<UpdateUserCommand, GetUserDto>
    {
        private readonly IRepository<Entity.AspNetUser> _userRepository;

        public UpdateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateUserCommandValidator validator,
            IRepository<Entity.AspNetUser> userRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _userRepository = userRepository;
        }

        public override async Task<ResponseDto<GetUserDto>> HandleCommand(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();

            var user = await _userRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (user != null)
            {
                _mapper?.Map(request.UpdateDto, user);
                await _userRepository.UpdateAsync(user);
            }

            var userDto = _mapper?.Map<GetUserDto>(user);
            if (userDto != null) response.UpdateData(userDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
