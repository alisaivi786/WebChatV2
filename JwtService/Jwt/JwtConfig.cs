using JwtService.Interface;

namespace JwtService.Jwt;
public class JwtConfig : IJwtConfig
{
    public string? SecretKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? TokenTime { get; set; }
}
