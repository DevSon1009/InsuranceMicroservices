using AuthService.Api.Commands;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    private readonly IUserStore userStore;
    private readonly ITokenService tokenService;

    public UserController(IUserStore userStore, ITokenService tokenService)
    {
        this.userStore = userStore;
        this.tokenService = tokenService;
    }

    /// <summary>Đăng nhập và nhận mã JWT.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(LoginResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<LoginResult> Login([FromBody] LoginCommand command)
    {
        var user = userStore.Validate(command.Login, command.Password);
        if (user is null)
        {
            return Unauthorized();
        }

        return Ok(tokenService.CreateToken(user));
    }
}
