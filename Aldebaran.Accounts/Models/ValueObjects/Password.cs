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
    
    public static implicit operator Password(string password) => new(password);
    
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

    public override string ToString()
    {
        return this._password;
    }
}