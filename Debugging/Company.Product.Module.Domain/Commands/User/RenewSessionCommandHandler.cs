using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Domain.Commands.Token;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Token;
using Company.Product.Module.Repository.Abstractions.Security;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Company.Product.Module.Domain.Commands.User
{
    public class RenewSessionCommandHandler : CommandHandlerBase<RenewSessionCommand, AccessTokenDto>
    {
        private readonly IUserIdentity _userIdentity;
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public RenewSessionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IUserIdentity userIdentity,
            UserManager<Entity.ApplicationUser> userManager
        ) : base(unitOfWork, mapper, mediator)
        {
            _userManager = userManager;
            _userIdentity = userIdentity;
        }

        public override async Task<ResponseDto<AccessTokenDto>> HandleCommand(RenewSessionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<AccessTokenDto>();
            var userName = _userIdentity.GetUserName();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return response;

            var accessToken = await _mediator?.Send(new GenerateTokenCommand(user), cancellationToken)!;

            if (accessToken.Data != null)
                response.UpdateData(accessToken.Data);

            return response;
        }
    }
}
