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
    
        public string GetCurrentUser()
            => GetUserNameClaim() ?? Constants.Security.User.Administrator;

        private string GetUserNameClaim()
            => GetClaims()?.FirstOrDefault(x => x.Type == "sub" || x.Type == "UserName")?.Value!;

        public string? GetCurrentUserId()
            => GetClaim<string?>("UserId");
    }
}
