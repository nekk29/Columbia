using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Domain.Commands.Token;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Token;
using $safesolutionname$.Repository.Abstractions.Security;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.User
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
