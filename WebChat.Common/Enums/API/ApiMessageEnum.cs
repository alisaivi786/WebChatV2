#region NameSpace
namespace WebChat.Common.Enums.API;
#endregion

#region ApiMessageEnum
#region ApiMessageEnum Summary
/// <summary>
/// All Kind Of Api Response Messages Enum
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public enum ApiMessageEnum
{
    #region Successful Operations

    /// <summary>
    /// Represents the message for a None API operation.
    /// </summary>
    [Description("None")]
    None = -1,

    #endregion

    #region Successful Operations

    /// <summary>
    /// Represents the message for a successful API operation.
    /// </summary>
    [Description("Operation completed successfully.")]
    Success = 0,

    #endregion

    #region Failed Operations

    /// <summary>
    /// Represents the message for a failed API operation.
    /// </summary>
    [Description("Operation failed.")]
    Failed = 1,

    #endregion

    #region Invalid API Version

    /// <summary>
    /// Represents the message for a Invalid API Version operation.
    /// </summary>
    [Description("Invalid API version specified.")]
    InValidVersion = 2,

    #endregion

    #region Valid API Version

    /// <summary>
    /// Represents the message for a valid API Version operation.
    /// </summary>
    [Description("Valid API version.")]
    ValidVersion = 3,

    #endregion

    #region Exception Occured

    /// <summary>
    /// Represents the message for a valid API Version operation.
    /// </summary>
    [Description("Excpetion Occured.")]
    Exception = 4,

    #endregion

    #region Authentication and Authorization

    /// <summary>
    /// Represents the message for a failed authentication.
    /// </summary>
    [Description("Authentication failed.")]
    Unauthorized = 401,

    /// <summary>
    /// Represents the message for insufficient permissions.
    /// </summary>
    [Description("Insufficient permissions.")]
    Forbidden = 403,

    #endregion

    #region Resource Not Found

    /// <summary>
    /// Represents the message for a resource not found.
    /// </summary>
    [Description("Resource not found.")]
    NotFound = 404,

    #endregion

    #region Method Not Allowed

    /// <summary>
    /// Represents the message for an HTTP method not allowed.
    /// </summary>
    [Description("HTTP method not allowed for the requested resource.")]
    MethodNotAllowed = 405,

    #endregion

    #region Conflict

    /// <summary>
    /// Represents the message for a conflicting operation.
    /// </summary>
    [Description("Conflicting operation.")]
    Conflict = 409,

    #endregion

    #region Internal Server Error

    /// <summary>
    /// Represents the message for an internal server error.
    /// </summary>
    [Description("Internal server error.")]
    InternalServerError = 500,

    #endregion
}

#endregion
