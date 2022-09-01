using System.Security.Claims;

namespace $safesolutionname$.Repository.Abstractions.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetCurrentUserClaims();
        string GetCurrentUser();
        int? GetCurrentUserId();
    }
}
