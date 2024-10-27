using AutoMapper;
using MediatR;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Domain.Commands.Client;
using $safesolutionname$.Dto.Application;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Client;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Application
{
    public class CreateApplicationCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        CreateApplicationCommandValidator validator,
        IRepository<Entity.Application> applicationRepository
    ) : CommandHandlerBase<CreateApplicationCommand, GetApplicationDto>(unitOfWork, mapper, mediator, validator)
    {
        public override async Task<ResponseDto<GetApplicationDto>> HandleCommand(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetApplicationDto>();
            var application = _mapper?.Map<Entity.Application>(request.CreateDto);

            if (application != null)
            {
                if (!request.CreateDto.IncludeClient) application.ClientId = null!;

                await applicationRepository.AddAsync(application);
                await applicationRepository.SaveAsync();

                if (request.CreateDto.IncludeClient)
                {
                    var createDto = new CreateOrUpdateClientDto
                    {
                        ApplicationCode = application!.Code,
                        OldApplicationCode = null!,
                        ApplicationName = application!.Name,
                        ApplicationUri = application!.ApplicationUri,
                        ApplicationLogoUri = application!.LogoUri,
                        SigninRedirectUri = request.CreateDto!.SigninRedirectUri,
                        RefreshRedirectUri = request.CreateDto!.RefreshRedirectUri,
                        PostLogoutRedirectUri = request.CreateDto!.PostLogoutRedirectUri,
                        AccessTokenLifetime = request.CreateDto!.AccessTokenLifetime,
                    };

                    var createClientResponse = await _mediator?.Send(new CreateOrUpdateClientCommand(createDto), cancellationToken)!;
                    if (!createClientResponse.IsValid)
                    {
                        response.AttachResults(createClientResponse);
                        return response;
                    }

                    application.ClientId = createClientResponse.Data!.ClientId;

                    await applicationRepository.UpdateAsync(application);
                    await applicationRepository.SaveAsync();
                }
            }

            var applicationDto = _mapper?.Map<GetApplicationDto>(application);
            if (applicationDto != null) response.UpdateData(applicationDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
