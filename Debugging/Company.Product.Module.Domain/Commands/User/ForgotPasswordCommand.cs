﻿using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.User;

namespace Company.Product.Module.Domain.Commands.User
{
    public class ForgotPasswordCommand(ForgotPasswordDto forgotPasswordDto) : CommandBase
    {
        public ForgotPasswordDto ForgotPasswordDto { get; set; } = forgotPasswordDto;
    }
}
