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
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.AspNetUser> _userRepository;
        private readonly IRepository<Entity.AspNetRole> _roleRepository;
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public UpdateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateUserCommandValidator validator,
            IRepository<Entity.AspNetUser> userRepository,
            IRepository<Entity.AspNetRole> roleRepository,
            UserManager<Entity.ApplicationUser> userManager
        ) : base(unitOfWork, mapper, validator)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public override async Task<ResponseDto<GetUserDto>> HandleCommand(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();

            var user = await _userRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (user != null)
            {
                _mapper?.Map(request.UpdateDto, user);
                await _userRepository.UpdateAsync(user);

                response.AddOkResult(Resources.Common.UpdateSuccessMessage);

                var roleIds = request.UpdateDto.RoleIds ?? new List<Guid>();
                var roles = await _roleRepository.FindByAsNoTrackingAsync(x => roleIds.Contains(x.Id));

                if (roles.Any())
                {
                    var applicationUser = await _userManager.FindByEmailAsync(user.Email);
                    var roleNames = await _userManager.GetRolesAsync(applicationUser);

                    var rolesToRemove = roleNames.Where(r => !roles.Select(x => x.Name).Contains(r));
                    if (rolesToRemove.Any())
                    {
                        var removeRolesResult = await _userManager.RemoveFromRolesAsync(applicationUser, roleNames);
                        if (!removeRolesResult.Succeeded)
                            removeRolesResult.Errors.ToList().ForEach(e => { response.AddErrorResult($"{e.Code}: {e.Description}"); });
                    }

                    var rolesToAdd = roles.Where(x => !roleNames.Contains(x.Name)).Select(x => x.NormalizedName);
                    if (rolesToAdd.Any())
                    {
                        var addRolesResult = await _userManager.AddToRolesAsync(applicationUser, rolesToAdd);
                        if (!addRolesResult.Succeeded)
                            addRolesResult.Errors.ToList().ForEach(e => { response.AddErrorResult($"{e.Code}: {e.Description}"); });
                    }
                }
            }

            var userDto = _mapper?.Map<GetUserDto>(user);
            if (userDto != null) response.UpdateData(userDto);

            return await Task.FromResult(response);
        }
    }
}
