namespace AuthService.Services;

public class JwtOptions
{
    public const string SectionName = "Jwt";

    /// <summary>Khóa ký HS256. Phải trùng với khóa trong AgentPortalApiGateway và ChatService.</summary>
    public string Key { get; set; } = string.Empty;

    public int ExpiresInMinutes { get; set; } = 60;
}
