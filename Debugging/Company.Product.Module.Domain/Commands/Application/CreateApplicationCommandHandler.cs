using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Domain.Commands.Client;
using Company.Product.Module.Dto.Application;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Client;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;

namespace Company.Product.Module.Domain.Commands.Application
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
