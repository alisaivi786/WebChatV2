#region NameSpace
using WebChat.Application.Filter;
using static System.Collections.Specialized.BitVector32;

namespace WebChat.Infrastructure.Services.SwaggerExtension; 
#endregion

#region SwaggerExtensions
#region SwaggerExtensions Summary
/// <summary>
/// SwaggerExtensions
/// Developer: ALI RAZA MUSHTAQ
/// Date: 07-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public static class SwaggerExtensions
{
    #region AddSwaggerWithVersioning
    #region AddSwaggerWithVersioning Summary
    /// <summary>
    /// AddSwaggerWithVersioning Service Infrastructure
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 07-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="services"></param> 
    #endregion
    public static void AddSwaggerWithVersioning(this IServiceCollection services)
    {
        #region AddSwaggerGen
        services.AddSwaggerGen(options =>
        {
            #region ...
            #region Configure Swagger to use versioning
            options.DocInclusionPredicate((version, desc) =>
                {
                    var versions = desc.CustomAttributes().OfType<ApiVersionAttribute>().SelectMany(attr => attr.Versions);
                    return versions.Any(v => $"v{v}" == version);
                });
            #endregion

            #region Add a Swagger document for each discovered API version
            foreach (var version in VersionHelper.GetApiVersions())
            {
                options.SwaggerDoc($"{version}", new OpenApiInfo
                {
                    Title = $"Chat.API {version}",
                    Version = $"{version}",
                });
            }
            #endregion

            //options.SchemaFilter<HideSchemaFilter>();

            #endregion

        }); 
        #endregion
    } 
    #endregion

}

#endregion