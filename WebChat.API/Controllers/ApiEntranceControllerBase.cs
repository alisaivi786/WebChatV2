namespace WebChat.API.Controllers;

public class ApiEntranceControllerBase : ControllerBase
{
    public IHttpContextAccessor _httpContextAccessor { get; set; }

    protected IActionResult ValidateRequest<T>(T request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Additional custom validation logic if needed

        return null; 
    }

    public async Task<T> ExecAsync<T>(Func<Task<T>> func, string msg) where T : ApiResponse, new()
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, msg);
            return new T() { Code = ApiCodeEnum.NetworkAbnormal, Msg = ex.Message };
        }
    }

   
    public async Task<T> ExecAsync<T, M>(M request, Func<StringBuilder, Task<T>> func, bool isWriteResult = true)
        where T : ApiResponse, new() where M : ApiRequest, new()
    {
        var isError = false;
        var controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"];
        var actionName = _httpContextAccessor.HttpContext.Request.RouteValues["action"];

        var watch = new Stopwatch();
        watch.Start();
        StringBuilder sbLog = new StringBuilder();
        try
        {
            sbLog.AppendLine($"请求参数:【{request.ToJson()}】");

            var result = await func(sbLog);

            if (isWriteResult) sbLog.AppendLine($"响应结果:【{result.ToJson()}】");
            return result;
        }
        catch (Exception ex)
        {
            isError = true;
            sbLog.AppendLine($"发生异常:【{ex.ToJson()}】");
            return new T() { Code = ApiCodeEnum.NetworkAbnormal, Msg = ex.Message };
        }
        finally
        {
            watch.Stop();
            sbLog.AppendLine($"接口总用时：[{((decimal)watch.ElapsedMilliseconds / 1000).ToDecimal(3)} 秒]");

            var logPath = $"{LogPathEnum.Interface}\\{controllerName ?? "Other"}\\{actionName ?? "Other"}";
            var logContent = $"{Environment.NewLine}{sbLog}";
            if (isError)
            {
                LogFileEnum.error.WriteLog(logContent, isHourSplit: false);
            }
            else
            {
                LogFileEnum.info.WriteLog(logContent, logPath: logPath, isHourSplit: false);
            }
        }
    }
}
