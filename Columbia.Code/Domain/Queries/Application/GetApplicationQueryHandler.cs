using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Application;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Application
{
    public class GetApplicationQueryHandler(
        IMapper mapper,
        ConfigurationDbContext configurationDbContext,
        IRepository<Entity.Application> applicationRepository
    ) : QueryHandlerBase<GetApplicationQuery, GetApplicationDto>(mapper)
    {
        protected override async Task<ResponseDto<GetApplicationDto>> HandleQuery(GetApplicationQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetApplicationDto>();
            var application = await applicationRepository.GetByAsync(x => x.Id == request.Id);
            var applicationDto = _mapper?.Map<GetApplicationDto>(application);

            if (applicationDto != null)
            {
                if (!string.IsNullOrEmpty(applicationDto.ClientId))
                {
                    var clientId = applicationDto.ClientId;
                    var client = await configurationDbContext.Clients
                        .Include(x => x.RedirectUris)
                        .Include(x => x.PostLogoutRedirectUris)
                        .FirstOrDefaultAsync(x => x.ClientId == clientId, cancellationToken);

                    if (client != null)
                    {
                        applicationDto.IncludeClient = true;
                        applicationDto.SigninRedirectUri = client.RedirectUris.FirstOrDefault(x => x.RedirectUri.Contains("signin"))?.RedirectUri;
                        applicationDto.SigninRedirectUri = applicationDto.SigninRedirectUri?.Replace($"{applicationDto.ApplicationUri}/", string.Empty);
                        applicationDto.RefreshRedirectUri = client.RedirectUris.FirstOrDefault(x => x.RedirectUri.Contains("refresh"))?.RedirectUri;
                        applicationDto.RefreshRedirectUri = applicationDto.RefreshRedirectUri?.Replace($"{applicationDto.ApplicationUri}/", string.Empty);
                        applicationDto.PostLogoutRedirectUri = client.PostLogoutRedirectUris.FirstOrDefault()?.PostLogoutRedirectUri;
                        applicationDto.PostLogoutRedirectUri = applicationDto.PostLogoutRedirectUri?.Replace($"{applicationDto.ApplicationUri}/", string.Empty);
                        applicationDto.AccessTokenLifetime = client.AccessTokenLifetime;
                    }
                }

                response.UpdateData(applicationDto);
            }

            return await Task.FromResult(response);
        }
    }
}
