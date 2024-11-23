using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Entities = IdentityServer4.EntityFramework.Entities;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Client;
using $safesolutionname$.Repository.Abstractions.Transactions;
using $safesolutionname$.Repository.Extensions;

namespace $safesolutionname$.Domain.Commands.Client
{
    public class CreateOrUpdateClientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CreateOrUpdateClientCommandValidator validator,
        ConfigurationDbContext configurationDbContext
    ) : CommandHandlerBase<CreateOrUpdateClientCommand, CreateOrUpdateClientResultDto>(unitOfWork, mapper, validator)
    {
        public override async Task<ResponseDto<CreateOrUpdateClientResultDto>> HandleCommand(CreateOrUpdateClientCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<CreateOrUpdateClientResultDto>();

            try
            {
                var client = await CreateOrUpdateClient(request, cancellationToken);

                await CreateIdentityResources(client, cancellationToken);
                await CreateApiResources(client, cancellationToken);
                await CreateClientCorsOrigins(client, cancellationToken);
                await CreateClientGrantTypes(client, cancellationToken);
                await CreateClientScopes(client, cancellationToken);
                await CreateClientUris(client, request.CreateDto, cancellationToken);

                response.UpdateData(new CreateOrUpdateClientResultDto
                {
                    ClientId = client.ClientId,
                });
            }
            catch (Exception ex)
            {
                response.AddErrorResult(Resources.Client.CreateOrUpdateClientErrorClient, ex);
            }

            return response;
        }

        private async Task<Entities.Client> CreateOrUpdateClient(CreateOrUpdateClientCommand request, CancellationToken cancellationToken)
        {
            var applicationCode = request.CreateDto.ApplicationCode;
            var oldApplicationCode = request.CreateDto.ApplicationCode;

            var client = default(Entities.Client);
            var applicationUri = request.CreateDto.ApplicationUri;
            var applicationName = request.CreateDto.ApplicationName ?? JsonNamingPolicy.CamelCase.ConvertName(applicationCode);

            var clientId = $"{applicationCode}".ToLower();
            var oldClientId = !string.IsNullOrEmpty(oldApplicationCode) ? $"{oldApplicationCode}".ToLower() : null;

            if (!string.IsNullOrEmpty(oldClientId))
                client = await configurationDbContext.Clients
                    .IncludeProperties(x => x.AllowedGrantTypes)
                    .IncludeProperties(x => x.AllowedScopes)
                    .IncludeProperties(x => x.AllowedCorsOrigins)
                    .IncludeProperties(x => x.RedirectUris)
                    .IncludeProperties(x => x.PostLogoutRedirectUris)
                    .FirstOrDefaultAsync(x => x.ClientId == oldClientId, cancellationToken);

            client ??= await configurationDbContext.Clients.FirstOrDefaultAsync(x => x.ClientId == clientId, cancellationToken);
            applicationUri = applicationUri?.EndsWith('/') == true ? applicationUri.Remove(0, applicationUri.Length - 1) : applicationUri;

            if (client == null)
            {
                client = new Entities.Client
                {
                    ClientId = clientId,
                    ClientName = applicationName,
                    ClientUri = applicationUri,
                    Description = applicationName,
                    LogoUri = request.CreateDto.ApplicationLogoUri,
                    AccessTokenLifetime = request.CreateDto.AccessTokenLifetime,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true,
                    FrontChannelLogoutUri = string.Empty,
                    BackChannelLogoutUri = string.Empty,
                    AllowOfflineAccess = true,
                    ClientClaimsPrefix = string.Empty,
                    PairWiseSubjectSalt = string.Empty,
                    UserCodeType = string.Empty,
                    NonEditable = true,
                };

                await configurationDbContext.Clients.AddAsync(client, cancellationToken);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                client.ClientId = clientId;
                client.ClientName = applicationName;
                client.ClientUri = applicationUri;
                client.Description = applicationName;
                client.LogoUri = request.CreateDto.ApplicationLogoUri;
                client.AccessTokenLifetime = request.CreateDto.AccessTokenLifetime;
                client.AlwaysIncludeUserClaimsInIdToken = true;
                client.AllowAccessTokensViaBrowser = true;
                client.FrontChannelLogoutUri = string.Empty;
                client.BackChannelLogoutUri = string.Empty;
                client.AllowOfflineAccess = true;
                client.ClientClaimsPrefix = string.Empty;
                client.PairWiseSubjectSalt = string.Empty;
                client.UserCodeType = string.Empty;
                client.NonEditable = true;

                configurationDbContext.Clients.Update(client);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }

            return client;
        }

        private async Task CreateIdentityResources(Entities.Client _, CancellationToken cancellationToken)
        {
            var identityResources = new List<Entities.IdentityResource>();

            await AddOrUpdateIdentityResource(identityResources, "openid", "Your user identifier", cancellationToken);
            await AddOrUpdateIdentityResource(identityResources, "profile", "User profile", cancellationToken);
            await AddOrUpdateIdentityResource(identityResources, "email", "Your email address", cancellationToken);
            await AddOrUpdateIdentityResource(identityResources, "role", "Your role(s)", cancellationToken);

            foreach (var identityResource in identityResources)
            {
                await configurationDbContext.IdentityResources.AddAsync(identityResource, cancellationToken);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task CreateApiResources(Entities.Client client, CancellationToken cancellationToken)
        {
            var apiResourceName = $"{client.ClientId}.apis";

            var apiResources = await configurationDbContext.ApiResources
                .Where(x => x.Name == apiResourceName)
                .ToListAsync(cancellationToken);

            foreach (var apiResource in apiResources)
            {
                configurationDbContext.ApiResources.Remove(apiResource);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }

            var newApiResources = new List<Entities.ApiResource>() {
                new () {
                    Name = apiResourceName,
                    Scopes = [ new () { Scope = apiResourceName } ]
                }
            };

            foreach (var newApiResource in newApiResources)
            {
                await configurationDbContext.ApiResources.AddAsync(newApiResource, cancellationToken);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task AddOrUpdateIdentityResource(List<Entities.IdentityResource> identityResources, string name, string description, CancellationToken cancellationToken)
        {
            var existingIdentityResource = await configurationDbContext.IdentityResources
                .FirstOrDefaultAsync(x => x.Name == name, cancellationToken);

            if (existingIdentityResource == null)
            {
                identityResources.Add(new Entities.IdentityResource
                {
                    Name = name,
                    Description = description
                });
            }
        }

        private async Task CreateClientCorsOrigins(Entities.Client client, CancellationToken cancellationToken)
        {
            var corsOrigins = await configurationDbContext.ClientCorsOrigins
                .Where(x => x.ClientId == client.Id)
                .ToListAsync(cancellationToken);

            foreach (var corsOrigin in corsOrigins)
            {
                configurationDbContext.ClientCorsOrigins.Remove(corsOrigin);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }

            var newCorsOrigins = new List<Entities.ClientCorsOrigin>() {
                new () { ClientId = client.Id, Origin = client.ClientUri }
            };

            foreach (var newCorsOrigin in newCorsOrigins)
            {
                await configurationDbContext.ClientCorsOrigins.AddAsync(newCorsOrigin, cancellationToken);
                await configurationDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task CreateClientGrantTypes(Entities.Client client, CancellationToken cancellationToken)
        {
            client.AllowedGrantTypes = [];

            configurationDbContext.Clients.Update(client);
            await configurationDbContext.SaveChangesAsync(cancellationToken);

            client.AllowedGrantTypes = [
                new() { GrantType = "code" },
                new() { GrantType = "implicit" },
                new() { GrantType = "client_credentials" },
            ];

            configurationDbContext.Clients.Update(client);
            await configurationDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateClientScopes(Entities.Client client, CancellationToken cancellationToken)
        {
            client.AllowedScopes = [];

            configurationDbContext.Clients.Update(client);
            await configurationDbContext.SaveChangesAsync(cancellationToken);

            var apisScope = $"{client.ClientId}.apis";

            client.AllowedScopes = [
                new() { Scope = "openid" },
                new() { Scope = "profile" },
                new() { Scope = "email" },
                new() { Scope = "role" },
                new() { Scope = apisScope },
            ];

            configurationDbContext.Clients.Update(client);
            await configurationDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateClientUris(Entities.Client client, CreateOrUpdateClientDto createDto, CancellationToken cancellationToken)
        {
            client.RedirectUris = [];
            client.PostLogoutRedirectUris = [];

            configurationDbContext.Clients.Update(client);
            await configurationDbContext.SaveChangesAsync(cancellationToken);

            var signinRedirectUri = string.IsNullOrEmpty(createDto.SigninRedirectUri) ? "auth/signin" : createDto.SigninRedirectUri;
            var refreshRedirectUri = string.IsNullOrEmpty(createDto.RefreshRedirectUri) ? "silent-refresh.html" : createDto.RefreshRedirectUri;
            var postLogoutRedirectUri = string.IsNullOrEmpty(createDto.PostLogoutRedirectUri) ? "auth/signout" : createDto.PostLogoutRedirectUri;

            client.RedirectUris = [
                new() { RedirectUri = $"{client.ClientUri}/{signinRedirectUri}" },
                new() { RedirectUri = $"{client.ClientUri}/{refreshRedirectUri}" },
            ];

            client.PostLogoutRedirectUris = [
                new() { PostLogoutRedirectUri = $"{client.ClientUri}/{postLogoutRedirectUri}" },
            ];

            configurationDbContext.Clients.Update(client);
            await configurationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
