using WebChat.Application.Version;

namespace WebChat.Application.Helpers;

#region VersionHelper
#region VersionHelper Summary
/// <summary>
/// Version Helper 
/// Developer: ALI RAZA MUSHTAQ
/// Date: 07-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public static class VersionHelper
{
    #region GetApiVersions
    /// <summary>
    /// Get Api Versions
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 07-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <returns>IEnumerable<ApiVersion> List</returns>
    public static IEnumerable<ApiVersionCode> GetApiVersions()
    {
        Type enumType = typeof(ApiVersionCode); // Use ApiVersionCode instead of ApiVersion

        if (!enumType.IsEnum)
        {
            throw new ArgumentException("The provided type must be an Enum.", nameof(ApiVersionCode));
        }

        return Enum.GetValues(enumType).Cast<ApiVersionCode>();
    }
    #endregion

    public static IEnumerable<ApiVersionInfo> GetAllApiVersions()
    {
        return Enum.GetValues(typeof(ApiVersionCode))
            .Cast<ApiVersionCode>()
            .Select(code => new ApiVersionInfo(
                code,
                $"{code}",
                $"WebChar.API {code}"));
    }

    public static ApiVersionInfo GetApiVersionInfo(ApiVersionCode code)
    {
        return GetAllApiVersions().FirstOrDefault(v => v.Code == code);
    }
}

#endregion