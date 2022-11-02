using $safesolutionname$.Domain.Commands.Base;

namespace $safesolutionname$.Domain.Commands.User
{
    public class ForgotPasswordCommand : CommandBase
    {
        public ForgotPasswordCommand(string email) => Email = email;
        public string Email { get; set; }
    }
}
