using System.Security.Claims;

namespace $safesolutionname$.Repository.Abstractions.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetClaims();
        T? GetClaim<T>(string type);
        string GetUserName();
        string GetCurrentUser();
        Guid? GetCurrentUserId();
    }
}
