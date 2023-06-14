namespace Aldebaran.Core.Shared.Messages;

public static class Constants
{
    public static class Messages
    {
        public static string NotFound(string parameter) => $"The {parameter} was not found.";
        
        public static string BadRequest(string error) => error;
    }
}