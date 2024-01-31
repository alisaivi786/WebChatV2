#region NameSpace
namespace WebChat.Common.Enums.API;
#endregion

#region ApiCodeEnum
#region ApiCodeEnum Summary
/// <summary>
/// All Kind Of Api Response Code Enum
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public enum ApiCodeEnum
{
    #region Default API Code Enums

    #region Successful Operations

    /// <summary>
    /// Represents the result of a successful API operation.
    /// </summary>
    [Description("Success")]
    Success = 0,

    #endregion

    #region Failed Operations

    /// <summary>
    /// Represents the result of a failed API operation.
    /// </summary>
    [Description("Failed")]
    Failed = 1,

    #endregion

    #endregion

    // Add more API-related status codes as needed
}
#endregion