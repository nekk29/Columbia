using AutoMapper;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Token;
using Company.Product.Module.Repository.Abstractions.Transactions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.Product.Module.Domain.Commands.Token
{
    public class GenerateTokenCommandHandler : CommandHandlerBase<GenerateTokenCommand, AccessTokenDto>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Entity.ApplicationUser> _userManager;

        public GenerateTokenCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration,
            UserManager<Entity.ApplicationUser> userManager
        ) : base(unitOfWork, mapper, mediator)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public override async Task<ResponseDto<AccessTokenDto>> HandleCommand(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var issuer = _configuration.GetValue<string>("SecurityOptions:Issuer");
            var audience = _configuration.GetValue<string>("SecurityOptions:Audience");
            var expiration = _configuration.GetValue<int>("SecurityOptions:ExpirationInSeconds");
            var securityKey = _configuration.GetValue<string>("SecurityOptions:SecurityKey");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var user = await _userManager.FindByNameAsync(request.User.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.User.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, request.User.Email, ClaimValueTypes.String),
                new Claim("UserId", request.User.Id.ToString()),
                new Claim("DisplayName", $"{request.User.FirstName} {request.User.LastName}"),
                new Claim("UserName", request.User.UserName),
                new Claim("Email", request.User.Email)
            };

            foreach (var role in roles)
                claims.Add(new Claim(Constants.Security.ClaimTypes.Role, role));

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromSeconds(expiration)),
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var accessTokenDto = new AccessTokenDto
            {
                access_token = encodedJwt,
                expires_in = expiration
            };

            var response = new ResponseDto<AccessTokenDto>(accessTokenDto);

            return await Task.FromResult(response);
        }
    }
}
