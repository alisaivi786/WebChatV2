using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using WebChat.Common.Enums.API;
using WebChat.Common.IBaseResponse;

namespace WebChat.Infrastructure.Middleware.ModelValidation;

public class ModelValidationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api")) // Adjust the path as needed
        {
            if (!context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase)) // Exclude GET requests if needed
            {
                if (context.Items["ModelState"] is ModelStateDictionary modelState && !modelState.IsValid)
                {
                    var validationResponse = new ApiResponse<object>
                    {
                        Code = ApiCodeEnum.Failed,
                        MsgCode = ApiMessageEnum.ModelValidation,
                        //List = GetExceptionList(exception)
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(validationResponse));
                                   
                    return;
                }
            }
        }

        await _next(context);
    }
}
