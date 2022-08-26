using System.Security.Claims;

namespace Company.Product.Module.Repository.Security
{
    public interface IUserIdentity
    {
        IEnumerable<Claim> GetCurrentUserClaims();
        string GetCurrentUser();
        int? GetCurrentUserId();
    }
}
