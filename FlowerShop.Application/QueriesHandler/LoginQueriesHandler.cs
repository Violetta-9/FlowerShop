
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlowerShop.Application.Configurations;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries;
using FlowerShop.Data.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlowerShop.Application.QueriesHandler
{
    public class LoginQueriesHandler : IRequestHandler<LoginUserQueries, string>
    {
        private readonly UserManager<ShopUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        public LoginQueriesHandler(UserManager<ShopUser> userManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Handle(LoginUserQueries request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.FindByNameAsync(request.User.UserLoginOrEmail);
            var checkPassword = await _userManager.CheckPasswordAsync(currentUser, request.User.Password);
            if (!checkPassword)
            {
                //todo:
            }

            var userClaim =await GetUserClaimsAsync(currentUser);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaim),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new
                    SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.JwtSecretKey)),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;

        }

        private async Task<List<Claim>> GetUserClaimsAsync(ShopUser user)
        {
            var roles =await _userManager.GetRolesAsync(user);
            var claimsList = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, user.UserName) };
            claimsList.AddRange(roles.Select(x=>new Claim(ClaimTypes.Role,x)));
            if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claimsList.Add(new(ClaimTypes.MobilePhone, user.PhoneNumber));
            }
            return claimsList;
        }
    }
}
