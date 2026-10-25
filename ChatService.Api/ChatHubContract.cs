namespace ChatService.Api;

/// <summary>Đường dẫn của SignalR hub; BlazorWasmClient kết nối tới {Services:Chat}/agentsChat.</summary>
public static class ChatHubRoutes
{
    public const string AgentsChat = "/agentsChat";
}

/// <summary>Tên các phương thức server gọi xuống client (khớp với Chat.razor).</summary>
public static class ChatHubMethods
{
    /// <summary>(string user, string avatar, string text)</summary>
    public const string ReceiveMessage = "ReceiveMessage";

    /// <summary>(string notification)</summary>
    public const string ReceiveNotification = "ReceiveNotification";
}
