using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Product.Module.Apis
{
    [ApiController]
    [Route("api/error")]
    public class ErrorController(IConfiguration configuration, IIdentityServerInteractionService interaction) : ControllerBase
    {
        [HttpGet]
        [Route("identity")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Identity(string errorId)
        {
            var errorMessage = await interaction.GetErrorContextAsync(errorId);
            var frontUrl = configuration.GetValue<string>("SecurityOptions:FrontUrl");
            return RedirectPermanent($"{frontUrl}/error/auth?error={errorMessage.Error}&errorDescription={errorMessage.ErrorDescription}");
        }

        [HttpGet]
        [Route("access-denied")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult AccessDenied(string _)
        {
            var frontUrl = configuration.GetValue<string>("SecurityOptions:FrontUrl");
            return RedirectPermanent($"{frontUrl}/error/unauthorized");
        }
    }
}
