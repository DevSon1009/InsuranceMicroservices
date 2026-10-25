using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Api.Commands;
using AuthService.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Services;

public class JwtTokenService : ITokenService
{
    private readonly JwtOptions options;

    public JwtTokenService(IOptions<JwtOptions> options)
    {
        this.options = options.Value;
    }

    public LoginResult CreateToken(UserAccount user)
    {
        var expires = DateTime.UtcNow.AddMinutes(options.ExpiresInMinutes);

        var claims = new List<Claim>
        {
            // Gateway đọc claim này để gắn header AgentLogin
            new(ClaimTypes.NameIdentifier, user.Login),
            new(ClaimTypes.Name, user.DisplayName),
            // Gateway kiểm tra RouteClaimsRequirement: userType = SALESMAN
            new("userType", user.UserType),
            new("avatar", user.Avatar)
        };
        claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Key));
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: expires,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

        return new LoginResult
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            UserName = user.DisplayName,
            Roles = user.Roles,
            Avatar = user.Avatar,
            UserType = user.UserType,
            ExpiresIn = expires
        };
    }
}
