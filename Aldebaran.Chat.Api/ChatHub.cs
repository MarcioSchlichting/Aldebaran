using Aldebaran.Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace Aldebaran.Chat.Api;

public sealed class ChatHub : Hub
{
    // For while ( when it going to a cloud, it should be changed)
    private static readonly List<ChatUser> messages = new();

    public override Task OnConnectedAsync()
    {
        var user = JsonConvert.DeserializeObject<ChatUser>(Context.GetHttpContext().Request.Query["user"]);
        _connections.Add(Context.ConnectionId, user);
        //Ao usar o método All eu estou enviando a mensagem para todos os usuários conectados no meu Hub
        Clients.All.SendAsync("chat", _connections.GetAllUser(), user);
        
        return base.OnConnectedAsync();
    }

    public void Send(Message message)
    {
        Clients.Client()
    }
}