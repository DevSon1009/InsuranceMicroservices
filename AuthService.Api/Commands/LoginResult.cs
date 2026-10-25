namespace AuthService.Api.Commands;

/// <summary>Kết quả đăng nhập thành công; khớp với AuthResponse của BlazorWasmClient.</summary>
public class LoginResult
{
    public string Token { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string[] Roles { get; set; } = Array.Empty<string>();
    public string Avatar { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty;
    public DateTime ExpiresIn { get; set; }
}
