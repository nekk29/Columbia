using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Email;

namespace Company.Product.Module.Domain.Commands.Email
{
    public class SendEmailCommand : CommandBase
    {
        public SendEmailCommand(SendEmailDto emailDto) => EmailDto = emailDto;
        public SendEmailDto EmailDto { get; set; }
    }
}
