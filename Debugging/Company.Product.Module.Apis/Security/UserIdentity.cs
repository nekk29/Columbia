using Company.Product.Module.Common;
using Company.Product.Module.Repository.Security;
using System.Security.Claims;

namespace Company.Product.Module.Apis.Security
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public IEnumerable<Claim> GetCurrentUserClaims()
            => _httpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>();

        public string GetCurrentUser() =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? Constants.Security.User.Admin;

        public int? GetCurrentUserId()
        {
            var userId = default(int?);
            var userIdClaim = GetCurrentUserClaims().FirstOrDefault(x => x.Type == "UserId")?.Value;
            if (userIdClaim != null) userId = int.Parse(userIdClaim);
            return userId;
        }
    }
}
