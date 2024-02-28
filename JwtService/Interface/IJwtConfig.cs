namespace JwtService.Interface;

public interface IJwtConfig
{
    public string? SecretKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? TokenTime { get; set; }
}
