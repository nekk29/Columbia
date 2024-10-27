using Company.Product.Module.Dto.Base;
using Microsoft.AspNetCore.Http;

namespace Company.Product.Module.Domain.Extensions
{
    public static class SecurityUserExtensions
    {
        public static string ReturnUrlOrDefault(this ReturnUrlDto returnUrlDto)
            => !string.IsNullOrEmpty(returnUrlDto.ReturnUrl) ? returnUrlDto.ReturnUrl : "/";

        public static string GetBaseUrl(this IHttpContextAccessor httpContextAccessor)
            => $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
    }
}
