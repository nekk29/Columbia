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
    public class CreateUserCommandHandler : CommandHandlerBase<CreateUserCommand, GetUserDto>
    {
        protected override bool UseTransaction => false;

        private readonly IConfiguration _configuration;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly UserManager<Entity.ApplicationUser> _userManager;
        private readonly IRepository<Entity.ApplicationUser> _applicationUserRepository;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateUserCommandValidator validator,
            IConfiguration configuration,
            ILogger<CreateUserCommandHandler> logger,
            UserManager<Entity.ApplicationUser> userManager,
            IRepository<Entity.ApplicationUser> applicationUserRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _applicationUserRepository = applicationUserRepository;
        }

        public override async Task<ResponseDto<GetUserDto>> HandleCommand(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetUserDto>();

            var applicationUser = _mapper?.Map<Entity.ApplicationUser>(request.CreateDto);

            if (applicationUser != null)
            {
                applicationUser.EmailConfirmed = true;

                _applicationUserRepository.UpdateAuditTrails(applicationUser);

                var result = await _userManager.CreateAsync(applicationUser, request.CreateDto.Password);

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e =>
                    {
                        response.AddErrorResult($"{e.Code}: {e.Description}");
                    });

                    return response;
                }

                response.AddOkResult(Resources.Common.CreateSuccessMessage);

                try
                {
                    await SendCreationEmail(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    response.AddErrorResult(Resources.User.CreateUserMailError);
                }

                var getUserDto = _mapper?.Map<GetUserDto>(applicationUser);
                if (getUserDto != null) response.UpdateData(getUserDto);
            }

            return response;
        }

        public async Task SendCreationEmail(CreateUserCommand request)
        {
            var sendMail = _configuration.GetValue<bool>("SignInOptions:SendMailOnSignUp");
            if (sendMail)
            {
                var application = _configuration.GetValue<string>("ApiOptions:Name");
                var frontUrlLogo = _configuration.GetValue<string>("SecurityOptions:FrontUrlLogo");

                var emailDto = new SendEmailDto
                {
                    EmailCode = Constants.Email.User.Registration,
                    ToEmails = new List<string> { request.CreateDto?.Email ?? string.Empty },
                    BodyParams = new Dictionary<string, string>
                    {
                        { "{APPLICATION}", application },
                        { "{LOGO}", frontUrlLogo },
                        { "{USER}", request.CreateDto?.UserName! },
                        { "{PASSWORD}", request.CreateDto?.Password! }
                    }
                };

                await _mediator!.Send(new SendEmailCommand(emailDto));
            }
        }
    }
}
