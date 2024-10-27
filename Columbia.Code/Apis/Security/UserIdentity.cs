using System.Security.Claims;
using $safesolutionname$.Common;
using $safesolutionname$.Repository.Abstractions.Security;

namespace $safesolutionname$.Apis.Security
{
    public class UserIdentity(IHttpContextAccessor httpContextAccessor) : IUserIdentity
    {
        public IEnumerable<Claim> GetClaims()
            => httpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>();

        public T? GetClaim<T>(string type)
        {
            var claimValue = default(T?);
            var claim = GetClaims().FirstOrDefault(x => x.Type == type)?.Value;
            if (claim != null) claimValue = (T?)Convert.ChangeType(claim, typeof(T?));
            return claimValue;
        }

        public string GetApplicationCode()
            => GetClaims()?.FirstOrDefault(x => x.Type == "ApplicationCode")?.Value!;

        public string GetCurrentUser()
            => GetUserName() ?? Constants.Security.User.Administrator;

        public string GetUserName()
            => GetClaims()?.FirstOrDefault(x => x.Type == "UserName")?.Value!;

        public Guid? GetCurrentUserId()
        {
            var userId = GetClaim<string>("UserId");
            var parsed = Guid.TryParse(userId, out Guid userGuid);
            return parsed ? userGuid : null;
        }
    }
}
