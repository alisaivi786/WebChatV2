#region NameSpace
namespace WebChat.Infrastructure.Services.ApiVersionExtension; 
#endregion

#region ApiVersioningExtension
#region ApiVersioningExtension Summary
/// <summary>
/// ApiVersioningExtension
/// Developer: ALI RAZA MUSHTAQ
/// Date: 07-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public static class ApiVersioningExtension
{
    #region ApiVersionInfrastructure
    #region ApiVersionInfrastructure Summary
    /// <summary>
    /// ApiVersionInfrastructure
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 07-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="services"></param>
    /// <returns>Return AddApiVersioning Service</returns> 
    #endregion
    public static IServiceCollection ApiVersionInfrastructure(this IServiceCollection services)
    {
        #region ...
        #region AddApiVersioning
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });
        #endregion

        #region Return Service
        return services;
        #endregion 
        #endregion
    } 
    #endregion
} 
#endregion
