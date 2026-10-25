namespace AuthService.Models;

public class UserAccount
{
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string UserType { get; init; } = string.Empty;
    public string[] Roles { get; init; } = Array.Empty<string>();
    public string Avatar { get; init; } = string.Empty;
}
