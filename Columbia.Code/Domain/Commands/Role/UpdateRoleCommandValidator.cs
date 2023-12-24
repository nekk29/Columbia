using FluentValidation;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Commands.Role
{
    public class UpdateRoleCommandValidator : CommandValidatorBase<UpdateRoleCommand>
    {
        private readonly IRepository<AspNetRole> _roleRepository;

        public UpdateRoleCommandValidator(IRepository<AspNetRole> roleRepository)
        {
            _roleRepository = roleRepository;

            RequiredInformation(x => x.UpdateDto)
                .DependentRules(() =>
                {
                    RequiredField(x => x.UpdateDto.Id, Resources.Role.Id);
                    RequiredString(x => x.UpdateDto.Name, Resources.Role.Name, 2, 256);
                })
                .DependentRules(() =>
                {
                    RuleFor(x => x.UpdateDto.Id)
                        .MustAsync(ValidateExistenceAsync)
                        .WithCustomValidationMessage();
                });
        }

        protected async Task<bool> ValidateExistenceAsync(UpdateRoleCommand command, Guid? id, ValidationContext<UpdateRoleCommand> context, CancellationToken cancellationToken)
        {
            if (!id.HasValue) return true;
            if (string.IsNullOrEmpty(command.UpdateDto.Name)) return true;
            if (string.IsNullOrEmpty(command.UpdateDto.NormalizedName)) return true;

            var exists = await _roleRepository.FindAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!exists)
                return CustomValidationMessage(context, Resources.Common.UpdateRecordNotFound);

            exists = await _roleRepository.FindAll().Where(x => x.Name!.ToLower() == command.UpdateDto.Name!.ToLower() && x.Id != id).AnyAsync(cancellationToken);
            if (exists)
                return CustomValidationMessage(context, Resources.Role.DuplicateRecordByRoleName);

            return true;
        }
    }
}
