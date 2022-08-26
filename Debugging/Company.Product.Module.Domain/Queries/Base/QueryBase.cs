using Company.Product.Module.Dto.Base;
using MediatR;

namespace Company.Product.Module.Domain.Queries.Base
{
    public class QueryBase : IRequest<ResponseDto>
    {

    }

    public class QueryBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
