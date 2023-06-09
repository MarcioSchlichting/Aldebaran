using System.Reflection.Metadata;

namespace Aldebaran.Domain.ApiResponses;

public class ServiceResponse<T>
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
    
    public ServiceResponse<T> AddMessage(string message)
    {
        _messages.Add(message);

        return this;
    }
}

public static class ServiceResponseExtensions
{
    public static ServiceResponse<T> NotFound<T>(this T response)
    {
        return new ServiceResponse<T>(response);
    }

    public static ServiceResponse<T> NotFound<T>(this ServiceResponse<T> serviceResponse, string parameter)
    {
        return serviceResponse
            .AddMessage(Constants
                .Messages
                .NotFound(parameter));
    }
}

public static class Constants
{
    public static class Messages
    {
        public static string NotFound(string parameter) => $"The {parameter} was not found.";
    }
}