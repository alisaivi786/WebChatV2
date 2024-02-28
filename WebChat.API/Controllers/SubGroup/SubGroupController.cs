#region NameSpace
namespace WebChat.API.Controllers.SubGroup; 
#endregion

[ApiVersion("1")]
[Route("api/v{version:apiVersion}")]
public class SubGroupController: BaseAuthController
{
    #region GetSubGroupDetails
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<SubGroupDetailRspDto>>>))]
    [HttpPost("GetSubGroup")]
    public async Task<IActionResult> GetSubGroupDetails(GetSubGroupReqDto reqest)
    {
        #region ...
        var response = await UnitOfWork.SubGroupRepository.GetSubGroupDetailsAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region SubGroup-Id
    [HttpGet("SubGroup-Id/{id}")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<SubGroupDetailRspDto>))]
    public async Task<IActionResult> Get(int id)
    {
        #region ...
        var response = await UnitOfWork.SubGroupRepository.GetSingleSubGroupDetailsAsync(id);
        return Ok(response);
        #endregion
    }
    #endregion

    #region AddSubGroup
    [HttpPost("AddSubGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Post([FromBody] AddSubGroupReqDto reqest)
    {
        #region ...
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await UnitOfWork.SubGroupRepository.AddSubGroupAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region UpdateSubGroup
    [HttpPost("UpdateSubGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Put([FromBody] UpdateSubGroupReqDto reqest)
    {
        #region ...
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await UnitOfWork.SubGroupRepository.UpdateSubGroupAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region DeleteSubGroup
    [HttpPost("DeleteSubGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteSubGroupReqDto request)
    {
        #region ...
        var response = await UnitOfWork.SubGroupRepository.DeleteSubGroupAsync(request);
        return Ok(response);
        #endregion
    }
    #endregion
}
