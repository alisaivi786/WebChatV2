using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.Application.Version;

namespace WebChat.API.Controllers.Version;

[ApiVersion("1")]
[ApiVersionNeutral]
[Route("api/v{version:apiVersion}")]
[ApiController]
public class VersionsController : ControllerBase
{
    [SwaggerResponse((int)ApiCodeEnum.Failed, "Invalid API version", typeof(ApiResponse<string>))]
    [HttpGet("invalid-version")]
    public IActionResult Get()
    {


        return BadRequest(new ApiResponse<string>
        {
            Code = ApiCodeEnum.Failed,
            MsgCode = ApiMessageEnum.InValidVersion,
            Data = null
        });
    }
   
    [SwaggerResponse((int)ApiCodeEnum.Success, "API version", typeof(ApiResponse<object>))]
    [HttpGet("api-version")]
    public IActionResult ApiVersion()
    {
        var allVersions = VersionHelper.GetAllApiVersions();
       
        var mappedVersions = allVersions.Select(version => new
        {
            Title = version.Title,
            VersionString = version.VersionString,
            // Other properties you want to include
        }).ToList();

        return Ok(new ApiResponse<object>
        {
            Code = ApiCodeEnum.Success,
            MsgCode = ApiMessageEnum.ValidVersion,
            Data = mappedVersions,
        });
    }
}
