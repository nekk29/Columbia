﻿using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;
using $safesolutionname$.EmailClient;
using $safesolutionname$.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace $safesolutionname$.Domain.Commands.User
{
    public class CreateUserCommandHandler : CommandHandlerBase<CreateUserCommand, GetUserDto>
    {
        protected override bool UseTransaction => false;

        private readonly IEmailClient _emailClient;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateUserCommandValidator validator,
            IEmailClient emailClient,
            IConfiguration configuration,
            UserManager<Entity.ApplicationUser> userManager
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _emailClient = emailClient;
            _configuration = configuration;
            _userManager = userManager;
        }

        public override async Task<ResponseDto<GetUserDto>> HandleCommand(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();

            var applicationUser = _mapper?.Map<Entity.ApplicationUser>(request.CreateDto);

            if (applicationUser != null)
            {
                applicationUser.Active = true;
                applicationUser.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(applicationUser, request.CreateDto.Password);

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e =>
                    {
                        response.AddErrorResult($"{e.Code}: {e.Description}");
                    });

                    return response;
                }

                await SendCreationEmail(request);

                var getUserDto = _mapper?.Map<GetUserDto>(applicationUser);
                if (getUserDto != null) response.UpdateData(getUserDto);

                response.AddOkResult(Resources.Common.CreateSuccessMessage);
            }

            return response;
        }

        public async Task SendCreationEmail(CreateUserCommand request)
        {
            var sendMail = _configuration.GetValue<bool>("SignInOptions:SendMailOnSignUp");

            if (sendMail)
            {
                var emailBody = Resources.User.CreateUserEmailBody;

                emailBody = emailBody.Replace("{APLICACION}", _configuration.GetValue<string>("ApiOptions:Name"));
                emailBody = emailBody.Replace("{USER}", request.CreateDto.UserName);
                emailBody = emailBody.Replace("{PASSWORD}", request.CreateDto.Password);

                await _emailClient.SendEmailAsync(
                    request.CreateDto?.Email ?? string.Empty,
                    Resources.User.CreateUserEmailSubject,
                    emailBody,
                    true
                );
            }
        }
    }
}
