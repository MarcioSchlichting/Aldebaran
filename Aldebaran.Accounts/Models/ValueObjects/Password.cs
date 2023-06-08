namespace Aldebaran.Accounts.Models.ValueObjects;

public readonly struct Password
{
    private readonly string _value;

    public Password(string value)
    {
        _value = value;
    }
    
    public static explicit operator Password(string value)
        => Validate(value) ? new Password(value) : throw new ArgumentException("Invalid password");

    private static bool Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
            return false;
        
        if (value.Length < 8)
            return false;

        return true;
    }
}