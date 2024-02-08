#region NameSpace
namespace WebChat.Common.IBaseResponse;
#endregion

#region Base ApiResponse
public class ApiResponse
{
    private string? _msg;
    //public object? Code { get; set; }
    public ApiCodeEnum? Code { get; set; } = ApiCodeEnum.Failed;
    public string Msg
    {
        get
        {
            if (MsgCode != ApiMessageEnum.None)
            {
                _msg = MsgCode.GetDescription();
            }
            return _msg;
        }
        set
        {
            _msg = value;
        }
    }
    public ApiMessageEnum MsgCode { get; set; } = ApiMessageEnum.Failed;
}
#endregion

#region Extended ApiResponse
public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }
}
#endregion

#region Extended ApiResponse with List
public class ApiResponseWithList<T> : ApiResponse
{
    public List<T>? List { get; set; }
}
#endregion
