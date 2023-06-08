using Aldebaran.Accounts.Shared;

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

    public static implicit operator string(Name value)
        => value.ToString();

    private static bool Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Invalid name");
        }
        
        int length = value.Length;
        
        if (length <= Constants.Name.MinLength)
            return false;

        if (length > Constants.Name.MaxLength)
            return false;

        return true;
    }

    public override string ToString()
    {
        return _value;
    }
}