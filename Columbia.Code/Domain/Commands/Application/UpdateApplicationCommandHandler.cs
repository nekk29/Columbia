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
    public class UpdateApplicationCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator,
        UpdateApplicationCommandValidator validator,
        IRepository<Entity.Application> applicationRepository
    ) : CommandHandlerBase<UpdateApplicationCommand, GetApplicationDto>(unitOfWork, mapper, mediator, validator)
    {
        public override async Task<ResponseDto<GetApplicationDto>> HandleCommand(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetApplicationDto>();

            var application = await applicationRepository.GetByAsync(x => x.Id == request.UpdateDto.Id);
            if (application != null)
            {
                var oldApplicationCode = application!.Code;

                _mapper?.Map(request.UpdateDto, application);

                if (!request.UpdateDto.IncludeClient) application.ClientId = null!;

                await applicationRepository.UpdateAsync(application);
                await applicationRepository.SaveAsync();

                if (request.UpdateDto.IncludeClient)
                {
                    var createDto = new CreateOrUpdateClientDto
                    {
                        ApplicationCode = application.Code,
                        OldApplicationCode = oldApplicationCode,
                        ApplicationName = application!.Name,
                        ApplicationUri = application!.ApplicationUri,
                        ApplicationLogoUri = application!.LogoUri,
                        SigninRedirectUri = request.UpdateDto!.SigninRedirectUri,
                        RefreshRedirectUri = request.UpdateDto!.RefreshRedirectUri,
                        PostLogoutRedirectUri = request.UpdateDto!.PostLogoutRedirectUri,
                        AccessTokenLifetime = request.UpdateDto!.AccessTokenLifetime,
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

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
