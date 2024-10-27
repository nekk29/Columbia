using System.Security.Claims;

namespace Company.Product.Module.Repository.Abstractions.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetClaims();
        T? GetClaim<T>(string type);
        string GetApplicationCode();
        string GetUserName();
        string GetCurrentUser();
        Guid? GetCurrentUserId();
    }
}
