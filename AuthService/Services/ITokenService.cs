using AuthService.Api.Commands;
using AuthService.Models;

namespace AuthService.Services;

public interface ITokenService
{
    LoginResult CreateToken(UserAccount user);
}
