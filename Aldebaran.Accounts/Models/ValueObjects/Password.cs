using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Aldebaran.Accounts.Models.ValueObjects;

public readonly struct Password
{
    private readonly string _password;

    public Password(string password)
    {
        _password = password;
    }
    
    public string Value => _password;

    public static Password EncryptPassword(string password)
    {
        byte[] salt = new byte[128 / 8]; // Generate a 128-bit salt using a secure PRNG
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        
        string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
        ));
        
        return encryptedPassw;
    }

    public override string ToString() => _password;

    public static bool operator ==(Password left, Password right) => left.Value == right.Value;

    public static bool operator !=(Password left, Password right) => !(left == right);

    public static implicit operator Password(string password) => new(password);
    
    public static implicit operator string(Password password) => password.ToString();
    
    public bool Equals(Password other) => _password == other._password;

    public override bool Equals(object? obj) => obj is Password other && Equals(other);

    public override int GetHashCode() => _password.GetHashCode();
}