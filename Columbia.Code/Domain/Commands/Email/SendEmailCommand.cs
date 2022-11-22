using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Email;

namespace $safesolutionname$.Domain.Commands.Email
{
    public class SendEmailCommand : CommandBase
    {
        public SendEmailCommand(SendEmailDto emailDto) => EmailDto = emailDto;
        public SendEmailDto EmailDto { get; set; }
    }
}
