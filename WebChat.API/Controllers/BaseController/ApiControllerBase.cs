using Microsoft.AspNetCore.Authorization;

namespace WebChat.API.Controllers.BaseController;


[Authorize(Roles = "Access_Token")]
public class ApiControllerBase : ApiEntranceControllerBase
{
    #region Exec Fun
    public T Exec<T>(Func<T> func, string msg) where T : ApiResponse, new()
    {
        try
        {
            return func();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, msg);
            return new T() { Code = ApiCodeEnum.NetworkAbnormal, Msg = ex.Message };
        }
    }

    #endregion

    #region Show Message

    public ApiResponse<M> ShowMsg<M>(bool result, M data = default)
    {
        if (result)
            return new ApiResponse<M>() { Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success, Data = data };
        else
            return new ApiResponse<M>() { Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.Failed, Data = data };
    }

    #endregion
}
