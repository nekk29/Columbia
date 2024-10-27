using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using Company.Product.Module.Common;
using Company.Product.Module.Repository.Abstractions.Base;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Company.Product.Module.Domain.Services.Security
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    public class CustomProfileService(
        UserManager<Entity.ApplicationUser> userManager,
        IRepository<Entity.AspNetRole> aspNetRoleRepository,
        IRepository<Entity.Application> applicationRepository,
        IUserClaimsPrincipalFactory<Entity.ApplicationUser> claimsFactory
    ) : ProfileService<Entity.ApplicationUser>(userManager!, claimsFactory), IProfileService
    {
        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await userManager.GetUserAsync(context.Subject);
            var roles = await userManager.GetRolesAsync(user!) ?? [];
            var application = await applicationRepository.GetByAsync(x => x.ClientId == context.Client.ClientId);

            Expression<Func<Entity.AspNetRole, bool>> filter = application == null ?
                x => roles.Contains(x.Name) :
                x => roles.Contains(x.Name) && x.Application.IsActive && x.Application.Code == application.Code;

            roles = await aspNetRoleRepository
                .FindAllAsNoTracking()
                .Where(filter)
                .Select(x => x.Name)
                .ToListAsync();

            var identityClaims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, user!.UserName!),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new (JwtRegisteredClaimNames.Email, user!.Email!, ClaimValueTypes.String),
                new ("UserId", user!.Id.ToString()),
                new ("DisplayName", $"{user!.FirstName} {user!.LastName}"),
                new ("UserName", user!.UserName!),
                new ("Email", user!.Email!),
            };

            foreach (var role in roles)
                identityClaims.Add(new Claim(Constants.Security.ClaimTypes.Role, role));

            context.IssuedClaims.AddRange(identityClaims);
        }
    }
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
}
