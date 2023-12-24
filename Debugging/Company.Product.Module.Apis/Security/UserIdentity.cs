using System.Security.Claims;
using Company.Product.Module.Common;
using Company.Product.Module.Repository.Abstractions.Security;

namespace Company.Product.Module.Apis.Security
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
            => GetUserName() ?? Constants.Security.User.Administrator;

        public string GetUserName()
            => GetClaims()?.FirstOrDefault(x => x.Type == "sub" || x.Type == "UserName")?.Value!;

        public Guid? GetCurrentUserId()
        {
            var userId = GetClaim<string>("UserId");
            var parsed = Guid.TryParse(userId, out Guid userGuid);
            return parsed ? userGuid : null;
        }
    }
}
