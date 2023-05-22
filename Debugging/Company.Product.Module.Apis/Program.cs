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

#region Services

// Cors
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.WithOrigins(configuration.GetValue<string>("AllowedHosts"))
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Controllers
builder.Services.AddControllers();

// Endpoints
builder.Services.AddEndpointsApiExplorer();

// Documentation
builder.Services.UseSwaggerDocumentation(configuration);

// Repositories
builder.Services.UseRepositories(configuration, typeof(Program).Assembly.GetName().Name!);

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

// Cors
app.UseCors("CorsPolicy");

// Localization
app.UseLocalization(
    configuration,
    new string[] {
        Constants.Culture.esESCulture,
        Constants.Culture.enUSCulture
    }
);

// CustomExceptionHandler
app.UseCustomExceptionHandler();

// Documentation
app.UseSwaggerDocumentation(configuration);

// HttpsRedirection
app.UseHttpsRedirection();

// Routing
app.UseRouting();

// Authentication
app.UseAuthentication();

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

// RootApiEndpoint
app.UseRootApiEndpoint(configuration);

// Run
app.Run();

#endregion
