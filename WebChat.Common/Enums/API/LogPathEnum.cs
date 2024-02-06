namespace WebChat.Common.Enums.API;

public enum LogPathEnum
{
    /// <summary>
    /// 默认根目录日志
    /// </summary>
    [Description("")]
    Null = 1,

    [Description("Pay")]
    Pay,

    [Description("User")]
    User,

    /// <summary>
    /// 慢日志
    /// </summary>
    [Description("SlowLog")]
    SlowLog,

    /// <summary>
    /// Http请求
    /// </summary>
    [Description("Http")]
    Http,

    /// <summary>
    /// 接口日志
    /// </summary>
    [Description("Interface")]
    Interface,
}
