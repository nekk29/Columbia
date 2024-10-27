using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Email;

namespace $safesolutionname$.Domain.Commands.Email
{
    public class SendEmailCommand(SendEmailDto emailDto) : CommandBase
    {
        public SendEmailDto EmailDto { get; set; } = emailDto;
    }
}
