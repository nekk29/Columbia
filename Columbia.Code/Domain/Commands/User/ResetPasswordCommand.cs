﻿using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Domain.Commands.User
{
    public class ResetPasswordCommand : CommandBase
    {
        public ResetPasswordCommand(ResetPasswordDto resetPasswordDto) => ResetPasswordDto = resetPasswordDto;
        public ResetPasswordDto ResetPasswordDto { get; set; }
    }
}