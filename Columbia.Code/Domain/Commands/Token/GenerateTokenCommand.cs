using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Token;
using $safesolutionname$.Entity;

namespace $safesolutionname$.Domain.Commands.Token
{
    public class GenerateTokenCommand : CommandBase<AccessTokenDto>
    {
        public GenerateTokenCommand(ApplicationUser user) => User = user;
        public ApplicationUser User { get; set; }
    }
}
