using System.Security.Claims;
using ChatService.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatService.Hubs;

[Authorize]
public class ChatHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Others.SendAsync(ChatHubMethods.ReceiveNotification, $"{GetUserName()} joined the chat");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.Others.SendAsync(ChatHubMethods.ReceiveNotification, $"{GetUserName()} left the chat");
        await base.OnDisconnectedAsync(exception);
    }

    /// <summary>Client gọi hubConnection.SendAsync("SendMessage", text).</summary>
    public async Task SendMessage(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        await Clients.All.SendAsync(ChatHubMethods.ReceiveMessage, GetUserName(), GetAvatar(), text.Trim());
    }

    private string GetUserName() =>
        FindClaim(ClaimTypes.Name, "unique_name", "name", ClaimTypes.NameIdentifier, "nameid") ?? "anonymous";

    private string GetAvatar() => FindClaim("avatar") ?? string.Empty;

    private string? FindClaim(params string[] types)
    {
        foreach (var type in types)
        {
            var value = Context.User?.FindFirst(type)?.Value;
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
        }

        return null;
    }
}
