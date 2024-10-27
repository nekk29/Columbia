using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Domain.Commands.User
{
    public class UpdateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UpdateUserCommandValidator validator,
        IRepository<Entity.AspNetUser> userRepository,
        IRepository<Entity.AspNetRole> roleRepository,
        UserManager<Entity.ApplicationUser> userManager
    ) : CommandHandlerBase<UpdateUserCommand, GetUserDto>(unitOfWork, mapper, validator)
    {
        protected override bool UseTransaction => false;

        public override async Task<ResponseDto<GetUserDto>> HandleCommand(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();

            var user = await userRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (user != null)
            {
                _mapper?.Map(request.UpdateDto, user);

                user.NormalizedEmail = user.Email?.ToUpper();
                user.NormalizedUserName = user.UserName?.ToUpper();

                await userRepository.UpdateAsync(user);
                await userRepository.SaveAsync();

                response.AddOkResult(Resources.Common.UpdateSuccessMessage);

                var roleIds = request.UpdateDto.RoleIds ?? new List<Guid>();
                var roles = await roleRepository.FindByAsNoTrackingAsync(x => roleIds.Contains(x.Id));

                if (roles.Any())
                {
                    var applicationUser = await userManager.FindByEmailAsync(user.Email!);
                    var roleNames = await userManager.GetRolesAsync(applicationUser!);

                    var rolesToRemove = roleNames.Where(r => !roles.Select(x => x.Name).Contains(r));
                    if (rolesToRemove.Any())
                    {
                        var removeRolesResult = await userManager.RemoveFromRolesAsync(applicationUser!, roleNames);
                        if (!removeRolesResult.Succeeded)
                            removeRolesResult.Errors.ToList().ForEach(e => { response.AddErrorResult($"{e.Code}: {e.Description}"); });
                    }

                    var rolesToAdd = roles.Where(x => !roleNames.Contains(x.Name!)).Select(x => x.NormalizedName);
                    if (rolesToAdd.Any())
                    {
                        var addRolesResult = await userManager.AddToRolesAsync(applicationUser!, rolesToAdd!);
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
