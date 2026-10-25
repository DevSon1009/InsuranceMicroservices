namespace AuthService.Api.Commands;

/// <summary>Yêu cầu đăng nhập gửi tới POST /api/User.</summary>
public class LoginCommand
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
