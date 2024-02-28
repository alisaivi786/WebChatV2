using Newtonsoft.Json;
using System.Net;
using WebChat.Common.Enums.API;
using WebChat.Common.IBaseResponse;

namespace WebChat.Infrastructure.Middleware.ExceptionMiddleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new ApiResponseWithList<object>
        {
            Code = ApiCodeEnum.Failed,
            MsgCode = ApiMessageEnum.Exception,
            List = GetExceptionList(exception)
        };

        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    }

    private static List<object> GetExceptionList(Exception exception)
    {
        var exceptionList = new List<object>();

        while (exception != null)
        {
            var exceptionInfo = new
            {
                Name = exception.GetType().FullName,
                Message = exception.Message
            };

            exceptionList.Add(exceptionInfo);
            exception = exception.InnerException;
        }

        return exceptionList;
    }
}