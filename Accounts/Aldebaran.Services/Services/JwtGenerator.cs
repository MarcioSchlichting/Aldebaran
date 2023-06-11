using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aldebaran.Accounts.Models;
using Aldebaran.Domain.Repositories.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Options = Aldebaran.Domain.Options;

namespace Aldebaran.Services.Services;

public interface IJwtGeneratorService
{
    JwtResponse GenerateToken(UserInfo user);
}

public class JwtGeneratorService : IJwtGeneratorService
{
    private readonly Options _options;

    public JwtGeneratorService(IOptionsSnapshot<Options> options)
    {
        _options = options.Value;
    }
    
    public JwtResponse GenerateToken(UserInfo user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Jwt.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.Name),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
        };
        var token = new JwtSecurityToken(_options.Jwt.Issuer,
            _options.Jwt.Audience,
            claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
        
        return new JwtResponse(generatedToken);
    }
}

public sealed record JwtResponse(string Token);