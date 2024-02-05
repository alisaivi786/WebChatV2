#region NameSpace
namespace WebChat.Application.Response;
#endregion

#region Base ApiResponse
public class ApiResponse
{
    private string? _msg;
    public object? Code { get; set; }
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
    public ApiMessageEnum MsgCode { get; set; } = ApiMessageEnum.None;
}
#endregion

#region Extended ApiResponse
public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }
} 
#endregion
