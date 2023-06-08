namespace Aldebaran.Accounts.Models.ValueObjects;

public struct Name
{
    private readonly string _value;

    public Name(string value)
    {
        _value = New(value);
    }
    
    public static string New(string value)
    {
        if (Validate(value))
            return value;
        
        throw new ArgumentException("Invalid name");
    }
    
    public static explicit operator Name(string value)
        => Validate(value) 
        ? new Name(value) 
        : throw new ArgumentException("Invalid name");

    private static bool Validate(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
        
        if (value.Length < 3)
            return false;

        return true;
    }
}