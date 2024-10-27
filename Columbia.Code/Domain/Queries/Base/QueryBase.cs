using MediatR;
using $safesolutionname$.Dto.Base;

namespace $safesolutionname$.Domain.Queries.Base
{
    public class QueryBase : IRequest<ResponseDto>
    {

    }

    public class QueryBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
