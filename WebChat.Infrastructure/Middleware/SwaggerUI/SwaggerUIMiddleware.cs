namespace WebChat.Infrastructure.Middleware.SwaggerUI;

#region SwaggerUIMiddleware
#region SwaggerUIMiddleware Summary
/// <summary>
/// SwaggerUIMiddleware
/// Developer: ALI RAZA MUSHTAQ
/// Date: 07-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public static class SwaggerUIMiddleware
{
    #region UseSwaggerWithUI
    #region UseSwaggerWithUI Summary
    /// <summary>
    /// UseSwaggerWithUI
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 07-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="app"></param> 
    #endregion
    public static void UseSwaggerWithUI(this IApplicationBuilder app)
    {
        #region UseSwaggerWithUI
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            foreach (var version in VersionHelper.GetApiVersions())
            {
                options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"Chat.API {version}");
            }

            // Specify the Swagger UI endpoint and UI path
            options.RoutePrefix = "api-doc";
            options.DocumentTitle = "Chat Documentation";
        });
        #endregion
    }
    #endregion
} 
#endregion
