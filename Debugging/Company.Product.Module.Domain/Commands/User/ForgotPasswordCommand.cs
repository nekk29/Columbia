using Company.Product.Module.Domain.Commands.Base;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ForgotPasswordCommand : CommandBase
    {
        public ForgotPasswordCommand(string email) => Email = email;
        public string Email { get; set; }
    }
}
