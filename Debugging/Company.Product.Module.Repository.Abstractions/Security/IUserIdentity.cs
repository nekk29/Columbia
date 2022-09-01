using System.Security.Claims;

namespace Company.Product.Module.Repository.Abstractions.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetCurrentUserClaims();
        string GetCurrentUser();
        int? GetCurrentUserId();
    }
}
