namespace WebChat.Common.Enums.API;

public enum LogFileEnum
{
    #region 通用

    [Description("info")]
    info = 1,

    [Description("debug")]
    debug,

    [Description("error")]
    error,

    [Description("warning")]
    warning,

    [Description("signatureError")]
    signatureError,

    [Description("unAuthorized")]
    unAuthorized,


    #endregion
}
