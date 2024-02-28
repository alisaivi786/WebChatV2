namespace JwtService.Interface;

public interface IAuthService
{
    Task<string> GenerateJwtToken(string userId);
    bool ValidateJwtToken(string token);
    Task<bool> ValidateJwtToken2(string token);
}
