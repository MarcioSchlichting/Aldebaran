namespace Aldebaran.Domain.ApiResponses;

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

public static class ServiceResponseExtensions
{
    public static ServiceResponse<T> NotFound<T>(string parameter) where T : new()
    {
        return new ServiceResponse<T>(new T())
            .AddMessage(Constants
                .Messages
                .NotFound(parameter));
    }
    
    public static ServiceResponse<T> BadRequest<T>(string parameter) where T : new()
    {
        return new ServiceResponse<T>(new T())
            .AddMessage(Constants
                .Messages
                .BadRequest(parameter));
    }

    public static ServiceResponse<T> NotFound<T>(this ServiceResponse<T> serviceResponse, string parameter) where T : new()
    {
        return serviceResponse
            .AddMessage(Constants
                .Messages
                .NotFound(parameter));
    }
}

public record BaseResponse()
{
    public static BaseResponse New() => new();
}

public static class Constants
{
    public static class Messages
    {
        public static string NotFound(string parameter) => $"The {parameter} was not found.";
        
        public static string BadRequest(string error) => error;
    }
}