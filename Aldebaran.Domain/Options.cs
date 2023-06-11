namespace Aldebaran.Domain;

public sealed class Options
{
    public string ConnectionString { get; set; }
    
    public JwtOptions Jwt { get; set; }

    public class JwtOptions
    {
        public string Key { get; set; }
        
        public string Issuer { get; set; }
        
        public string Audience { get; set; }
    }
}