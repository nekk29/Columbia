using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using $safesolutionname$.Domain.Services.Security;
using $safesolutionname$.Repository.Abstractions.Security;
using $safesolutionname$.Repository.Data;

namespace $safesolutionname$.Apis.Security
{
    public static class SecurityExtensions
    {
        public static IServiceCollection UseSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var basePath = configuration.GetValue<string>("ApiOptions:BasePath");
            var issuerUri = configuration.GetValue<string>("SecurityOptions:Issuer");
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var migrationsAssembly = "$safesolutionname$.Apis";

            var authorityUri = configuration.GetValue<string>("SecurityOptions:Issuer");
            var validAudience = configuration.GetValue<string>("SecurityOptions:Audience");
            var securityKey = configuration.GetValue<string>("SecurityOptions:SecurityKey");
            var expirationInSeconds = configuration.GetValue<int>("SecurityOptions:ExpirationInSeconds");

            #region SecurityDbContext
            services.AddSqlServer<SecurityDbContext>(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
            #endregion

            #region Identity
            services
                .AddIdentity<Entity.ApplicationUser, Entity.ApplicationRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region IdentityOptions
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                if (configuration.GetValue<bool>("SignInOptions:LockoutEnabled"))
                {
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("SignInOptions:LockoutMaxFailedAccessAttempts");
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("SignInOptions:LockoutDefaultTimeSpanInMinutes"));
                }
            });
            #endregion

            #region IdentityServer
            services
                .AddIdentityServer(options =>
                {
                    options.IssuerUri = issuerUri;
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.UserInteraction.LoginUrl = $"{basePath}/api/user/login";
                    options.UserInteraction.LoginReturnUrlParameter = "returnUrl";
                    options.UserInteraction.LogoutUrl = $"{basePath}/api/user/logout";
                    options.UserInteraction.LogoutIdParameter = "returnUrl";
                    options.UserInteraction.ErrorUrl = $"{basePath}/api/error/identity";
                })
                .AddAspNetIdentity<Entity.ApplicationUser>()
                .AddProfileService<CustomProfileService>()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = (b =>
                        b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
                    );
                });
            #endregion

            #region Authentication
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie("Cookies", options =>
                {
                    options.Cookie.IsEssential = true;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    options.LoginPath = $"{basePath}/api/user/login";
                    options.AccessDeniedPath = $"{basePath}/api/error/access-denied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true;
                })
                .AddCertificate(options =>
                {
                    options.AllowedCertificateTypes = CertificateTypes.All;
                    options.RevocationMode = X509RevocationMode.NoCheck;
                });
            #endregion

            #region Authorization
            services
                .AddAuthorization(configure =>
                {
                    //configure.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAssertion(_ => true).Build();
                })
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.Authority = authorityUri;
                    opt.Audience = validAudience;

                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuerUri,
                        ValidateAudience = true,
                        ValidAudience = validAudience,
                        RequireSignedTokens = false,
                        ValidateIssuerSigningKey = false,
                        SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                        {
                            var jwt = new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(token);

                            return jwt;
                        },
                    };

                    opt.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            // Registra el error de autenticación aquí
                            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            // Registra el error de desafío aquí
                            Console.WriteLine($"Authentication challenge: {context.Error}");
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            // Registra el error de acceso prohibido aquí
                            Console.WriteLine("Access forbidden. User does not have the necessary permissions.");
                            return Task.CompletedTask;
                        }
                    };
                });
            #endregion

            #region UserIdentity
            services.AddScoped<IUserIdentity, UserIdentity>();
            #endregion

            return services;
        }
    }
}
