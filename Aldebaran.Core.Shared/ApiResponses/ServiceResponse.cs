using Aldebaran.Core.Shared.Messages;

namespace Aldebaran.Core.Shared.ApiResponses;

public class ServiceResponse<T> where T : new()
{
    private readonly IList<string> _messages;

    public ServiceResponse(IList<string> messages, T response)
    {
        _messages = messages;
        Response = response;
    }

    public ServiceResponse(T response)
    {
        _messages = new List<string>();
        Response = response;
    }
    
    public T Response { get; }
    
    public bool HasErrors => _messages.Any();
    
    public IReadOnlyList<string> Messages => _messages.ToList();

    public ServiceResponse<T> AddMessage(string message)
    {
        _messages.Add(message);

        return this;
    }
}