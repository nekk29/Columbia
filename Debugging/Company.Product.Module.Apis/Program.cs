using Company.Product.Module.Apis.Documentation;
using Company.Product.Module.Apis.Endpoints;
using Company.Product.Module.Apis.Exception;
using Company.Product.Module.Apis.Security;
using Company.Product.Module.Application.Extensions;
using Company.Product.Module.Domain.Extensions;
using Company.Product.Module.EmailClient;
using Company.Product.Module.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

#region Services

// Controllers
builder.Services.AddControllers();

// Endpoints
builder.Services.AddEndpointsApiExplorer();

// Documentation
builder.Services.UseSwaggerDocumentation(configuration);

// Repositories
builder.Services.UseRepositories(configuration);

// Domain Services
builder.Services.UseDomainServices();

// Application Services
builder.Services.UseApplicationServices();

// Security
builder.Services.UseSecurity(configuration);

// EmailClient
builder.Services.UseEmailClient(configuration);

#endregion

#region App

var app = builder.Build();

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
