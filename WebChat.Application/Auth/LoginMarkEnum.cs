namespace WebChat.Application.Auth;

public enum LoginMarkEnum
{
    [Description("unknown")]
    unknown = -1,
    
    [Description("PC")]
    PC = 0,
    
    [Description("Android")]
    Android = 1,
    
    [Description("IOS")]
    IOS = 2,
    
    [Description("H5")]
    H5 = 3
}
