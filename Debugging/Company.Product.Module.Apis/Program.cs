using Company.Product.Module.Apis.Documentation;
using Company.Product.Module.Apis.Endpoints;
using Company.Product.Module.Apis.Exception;
using Company.Product.Module.Apis.Localization;
using Company.Product.Module.Apis.Security;
using Company.Product.Module.Application.Extensions;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Extensions;
using Company.Product.Module.EmailClient;
using Company.Product.Module.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var migrationsAssembly = typeof(Program).Assembly.GetName().Name!;

#region Services

// Cors
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("all", builder =>
    {
        builder.WithOrigins(configuration.GetValue<string>("AllowedHosts")!)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
    setup.AddPolicy("login", builder =>
    {
        builder.WithOrigins(configuration.GetValue<string>("SecurityOptions:FrontUrl")!)
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Controllers
builder.Services.AddControllers();

// Endpoints
builder.Services.AddEndpointsApiExplorer();

// Documentation
builder.Services.UseSwaggerDocumentation(configuration);

// Repositories
builder.Services.UseRepositories(configuration, migrationsAssembly);

// Domain Services
builder.Services.UseDomainServices();

// Application Services
builder.Services.UseApplicationServices();

// Security
builder.Services.UseSecurity(configuration);

// EmailClient
builder.Services.UseEmailClient(configuration);

// Cache
builder.Services.AddMemoryCache();

#endregion

#region App

var app = builder.Build();

// Localization
app.UseLocalization(
    configuration,
    [
        Constants.Culture.esESCulture,
        Constants.Culture.enUSCulture
    ]
);

// CookiePolicy
app.UseCookiePolicy();

// CustomExceptionHandler
app.UseCustomExceptionHandler();

// Documentation
app.UseSwaggerDocumentation(configuration);

// HttpsRedirection
app.UseHttpsRedirection();

// Routing
app.UseRouting();

// CertificateForwarding
app.UseCertificateForwarding();

// Cors
app.UseCors("all");

// Authentication
app.UseAuthentication();

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

// RootApiEndpoint
app.UseRootApiEndpoint(configuration);

// IdentityServer
app.UseIdentityServer();

// Run
app.Run();

#endregion
