namespace WebChat.Application.Version;

public class ApiVersionInfo(ApiVersionCode code, string versionString, string title)
{
    public ApiVersionCode Code { get; set; } = code;
    public string VersionString { get; set; } = versionString;
    public string Title { get; set; } = title;
}
