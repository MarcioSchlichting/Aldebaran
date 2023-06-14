using Aldebaran.Core.Shared.Messages;

namespace Aldebaran.Core.Shared.ApiResponses;

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