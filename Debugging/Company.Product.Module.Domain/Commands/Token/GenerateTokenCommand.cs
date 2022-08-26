using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Token;
using Company.Product.Module.Entity;

namespace Company.Product.Module.Domain.Commands.Token
{
    public class GenerateTokenCommand : CommandBase<AccessTokenDto>
    {
        public GenerateTokenCommand(ApplicationUser user) => User = user;
        public ApplicationUser User { get; set; }
    }
}
