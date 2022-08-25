using $safesolutionname$.Dto.Base;
using MediatR;

namespace $safesolutionname$.Domain.Queries.Base
{
    public class QueryBase : IRequest<ResponseDto>
    {

    }

    public class QueryBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
