using $safesolutionname$.Dto.Base;
using MediatR;

namespace $safesolutionname$.Domain.Commands.Base
{
    public class CommandBase : IRequest<ResponseDto>
    {

    }

    public class CommandBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
