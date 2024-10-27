using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Email;

namespace Company.Product.Module.Domain.Commands.Email
{
    public class SendEmailCommand(SendEmailDto emailDto) : CommandBase
    {
        public SendEmailDto EmailDto { get; set; } = emailDto;
    }
}
