#region NameSpace
namespace WebChat.Common.Enums.DB; 
#endregion

#region DbCodeEnums
#region DbCodeEnums Summary
/// <summary>
/// All Kind Of DB Response Code Enum
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public enum DbCodeEnums
{
    [Description("System Error")]
    SystemError = -1,

    [Description("Db Connection Error")]
    DbConnectionError = -2,

    [Description("Success")]
    Success = 0,

    [Description("Failed")]
    Failed = 1,

    [Description("DbException")]
    DbException = 2,
    
    [Description("Canceled")]
    Canceled = 3,
}

#endregion