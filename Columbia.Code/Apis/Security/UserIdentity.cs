using $safesolutionname$.Common;
using $safesolutionname$.Repository.Abstractions.Security;
using System.Security.Claims;

namespace $safesolutionname$.Apis.Security
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public IEnumerable<Claim> GetClaims()
            => _httpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>();

        public T? GetClaim<T>(string type)
        {
            var claimValue = default(T?);
            var claim = GetClaims().FirstOrDefault(x => x.Type == type)?.Value;
            if (claim != null) claimValue = (T?)Convert.ChangeType(claim, typeof(T?));
            return claimValue;
        }

        public string GetCurrentUser() =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? Constants.Security.User.Admin;

        public string? GetCurrentUserId()
            => GetClaim<string?>("UserId");
    }
}
