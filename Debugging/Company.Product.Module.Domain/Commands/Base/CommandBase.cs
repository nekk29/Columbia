using Company.Product.Module.Dto.Base;
using MediatR;

namespace Company.Product.Module.Domain.Commands.Base
{
    public class CommandBase : IRequest<ResponseDto>
    {

    }

    public class CommandBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
