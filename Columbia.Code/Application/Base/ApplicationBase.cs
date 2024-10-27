using AutoMapper;
using MediatR;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Application.Base
{
    public class ApplicationBase(IMediator mediator)
    {
        protected readonly IMapper? _mapper;
        protected readonly IMediator _mediator = mediator;
        protected readonly IUnitOfWork? _unitOfWork;

        public ApplicationBase(IMediator mediator, IMapper mapper) : this(mediator)
            => _mapper = mapper;

        public ApplicationBase(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork) : this(mediator, mapper)
            => _unitOfWork = unitOfWork;
    }
}
