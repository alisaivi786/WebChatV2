#region NameSpace
using JwtService;
using JwtService.Interface;
using JwtService.Jwt;

namespace WebChat.Infrastructure.Services.JWT; 
#endregion

#region JWTAuthenticationExtension
#region JWTAuthenticationExtension Summary
/// <summary>
/// JWTAuthenticationExtension
/// Developer: ALI RAZA MUSHTAQ
/// Date: 15-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public static class JWTAuthenticationExtension
{
    #region AddJWTInfrastructure
    #region AddJWTInfrastructure Summary
    /// <summary>
    /// AddJWTInfrastructure
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 15-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="services"></param>
    /// <param name="appSettings"></param> 
    #endregion
    public static void AddJWTInfrastructure(this IServiceCollection services, IAppSettings appSettings)
    {
        #region ....

        services.AddSingleton<IJwtConfig>(new JwtConfig() { 
            SecretKey = appSettings.JwtSecretKey,
            Issuer = appSettings.JwtIssuer,
            Audience = appSettings.JwtAudience,
            TokenTime = appSettings.JwtTokenTime,
        });

        services.AddScoped<IAuthService, AuthService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = $"{appSettings.JwtIssuer}",
                    ValidAudience = $"{appSettings.JwtAudience}",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey))
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        // Custom validation logic can be added here if needed
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        // Handle authentication failure
                        return Task.CompletedTask;
                    }
                };
            });
        #endregion
    }
    #endregion
}

#endregion