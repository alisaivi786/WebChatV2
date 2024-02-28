#region NameSpace
using JwtService.Interface;
namespace JwtService; 
#endregion

#region AuthService

#region Summary
/// <summary>
/// JwtService
/// Developer: ALI RAZA MUSHTAQ
/// Date: 15-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuthService"/> class.
/// </remarks>
/// <param name="secretKey">The secret key.</param>
/// <param name="issuer">The issuer.</param>
/// <param name="audience">The audience.</param>
/// <param name="expireTime">The expire time.</param> 
#endregion
public class AuthService(IJwtConfig jwtConfig) : IAuthService
{
    #region Init()
    private readonly IJwtConfig JwtConfig = jwtConfig;
    #endregion

    #region GenerateJwtToken
    #region Summary
    /// <summary>
    /// Generates a JWT token.
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 15-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>JWT token.</returns> 
    #endregion
    public async Task<string> GenerateJwtToken(string userId)
    {
        #region ...
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var expValue = new DateTimeOffset(DateTime.Now.AddMinutes(Convert.ToInt32(JwtConfig.TokenTime))).ToUnixTimeSeconds();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
            new(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
            new(JwtRegisteredClaimNames.Exp,$"{expValue}"),
            new(ClaimTypes.Expiration, DateTime.Now.AddMinutes(Convert.ToInt32(JwtConfig.TokenTime)).ToString()),
            new(ClaimTypes.Name, userId),
            new(AuthClaimTypes.UserId,userId),
        };

        var jwt = new JwtSecurityToken(
               issuer: JwtConfig.Issuer,
               audience: JwtConfig.Audience,
               claims: claims,
               signingCredentials: credentials
           );

        var tokenHandler = new JwtSecurityTokenHandler();
        var encodedJwt = tokenHandler.WriteToken(jwt);

        return encodedJwt;
        #endregion
    }
    #endregion

    #region ValidateJwtToken
    #region Summary
    /// <summary>
    /// Validates a JWT token.
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 15-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="token">The JWT token.</param> 
    #endregion
    public bool ValidateJwtToken(string token)
    {
        #region ....
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecretKey));

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtConfig.Issuer,
            ValidAudience = JwtConfig.Audience,
            IssuerSigningKey = securityKey,
        };

        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            return true; // Token is valid
        }
        catch
        {
            return false; // Token validation failed
        }
        #endregion
    }
    #endregion


    public async Task<bool> ValidateJwtToken2(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero, // Adjust this if necessary
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecretKey)),
            ValidIssuer = JwtConfig.Issuer,
            ValidAudience = JwtConfig.Audience
        };

        try
        {
            SecurityToken validatedToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            // You can add more custom validation logic here if needed

            return true;
        }
        catch (SecurityTokenException)
        {
            // Token validation failed
            return false;
        }
    }


}
#endregion
