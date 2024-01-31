#region NameSpace
namespace WebChat.Application.Response;
#endregion

#region DbResponse
#region DbResponse Summary
/// <summary>
/// DbResponse
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
/// <typeparam name="T"></typeparam> 
#endregion
//public class DbResponse<T>
//{
//    public T? Data { get; set; }
//    public object? Code { get; set; }
//    public DbMessageEnums Message { get; set; }
//    public List<ErrorModel>? Error { get; set; }
//}

#endregion

#region Base DbResponse
public class DbResponse
{
    private string? _msg;
    public object? Code { get; set; }
    public string Message
    {
        get
        {
            if (MsgCode != DbMessageEnums.None)
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
    public DbMessageEnums MsgCode { get; set; } = DbMessageEnums.None;
    public List<ErrorModel>? Error { get; set; }
}
#endregion

#region Extended DbResponse
public class DbResponse<T> : DbResponse
{
    public T? Data { get; set; }
}
#endregion