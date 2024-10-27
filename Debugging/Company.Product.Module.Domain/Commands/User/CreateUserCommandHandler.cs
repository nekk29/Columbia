﻿using AutoMapper;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Domain.Commands.Email;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Email;
using Company.Product.Module.Dto.User;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Company.Product.Module.Domain.Commands.User
{
    public class CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        CreateUserCommandValidator validator,
        IConfiguration configuration,
        ILogger<CreateUserCommandHandler> logger,
        IRepository<Entity.AspNetRole> roleRepository,
        UserManager<Entity.ApplicationUser> userManager,
        IRepository<Entity.ApplicationUser> applicationUserRepository
    ) : CommandHandlerBase<CreateUserCommand, GetUserDto>(unitOfWork, mapper, mediator, validator)
    {
        protected override bool UseTransaction => false;

        public override async Task<ResponseDto<GetUserDto>> HandleCommand(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();

            var applicationUser = _mapper?.Map<Entity.ApplicationUser>(request.CreateDto);

            if (applicationUser != null)
            {
                applicationUser.EmailConfirmed = true;

                applicationUserRepository.UpdateAuditTrails(applicationUser);

                var result = await userManager.CreateAsync(applicationUser, request.CreateDto.Password!);

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e =>
                    {
                        response.AddErrorResult($"{e.Code}: {e.Description}");
                    });

                    return response;
                }

                if (response.IsValid)
                    response.AddOkResult(Resources.Common.CreateSuccessMessage);

                var roleIds = request.CreateDto.RoleIds ?? new List<Guid>();
                var roles = await roleRepository.FindByAsNoTrackingAsync(x => roleIds.Contains(x.Id));

                if (roles.Any())
                {
                    var addRolesResult = await userManager.AddToRolesAsync(applicationUser, roles.Select(x => x.NormalizedName)!);
                    if (!addRolesResult.Succeeded)
                        addRolesResult.Errors.ToList().ForEach(e => { response.AddErrorResult($"{e.Code}: {e.Description}"); });
                }

                try
                {
                    await SendCreationEmail(request);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Message: {Message}", ex.Message);
                    response.AddWarningResult(Resources.User.CreateUserMailError);
                }

                var getUserDto = _mapper?.Map<GetUserDto>(applicationUser);
                if (getUserDto != null) response.UpdateData(getUserDto);
            }

            return response;
        }

        public async Task SendCreationEmail(CreateUserCommand request)
        {
            var sendMail = configuration.GetValue<bool>("SignInOptions:SendMailOnSignUp");
            if (sendMail)
            {
                var application = configuration.GetValue<string>("ApiOptions:Name");
                var frontUrlLogo = configuration.GetValue<string>("SecurityOptions:FrontUrlLogo");

                var emailDto = new SendEmailDto
                {
                    EmailCode = Constants.Email.User.Registration,
                    ToEmails = new List<string> { request.CreateDto?.Email ?? string.Empty },
                    BodyParams = new Dictionary<string, string>
                    {
                        { "{APPLICATION}", application! },
                        { "{LOGO}", frontUrlLogo! },
                        { "{USER}", request.CreateDto?.UserName! },
                        { "{PASSWORD}", request.CreateDto?.Password! }
                    }
                };

                await _mediator!.Send(new SendEmailCommand(emailDto));
            }
        }
    }
}
