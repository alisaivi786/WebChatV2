using WebChat.Common.Dto.RequestDtos.LotteryUsers;

namespace WebChat.API.Controllers.ChatGroup;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}")]
public class ChatGroupController(IUnitOfWork UnitOfWork) : BaseAuthController
{
    private readonly IUnitOfWork unitOfWork = UnitOfWork;

    #region GetChatGroupDetails
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<ResponseModel>>>))]
    [HttpPost("GetChatGroupUsers")]
    public async Task<ApiResponse<PageBaseResponse<List<ResponseModel>>>> GetChatGroupUserDetails(GetGroupUserReqDto reqest)
    {
        var response = await unitOfWork.GroupUserRepository.GetGroupUserDetailsAsync(reqest);

        GetUserDetailsReqDto getUserDetailsReqDto = new()
        {
            ListOfUserIds = response.Data?.List?.Select(x => Convert.ToInt32(x.UserId)).ToList()
        };

        PageBaseResponse<List<ResponseModel>>  result = new();
        if (getUserDetailsReqDto?.ListOfUserIds?.Count != 0)
        {
            var res = await unitOfWork.UserRepository.GetUserDetailsAsync(null);

            // Joining the results based on UserId
            var joinedResult = response.Data?.List
                .Join(res.Data,
                    responseItem => Convert.ToInt32(responseItem.UserId),
                    resItem => resItem.UserId,
                    (responseItem, resItem) => new ResponseModel
                    {
                        UserId = (long)responseItem.UserId,
                        UserName = resItem.UserName,
                        NickName = resItem.NickName,
                        UserPhoto = resItem.UserPhoto,
                        GroupId = (long)responseItem.GroupId,
                        SubGroupId = (long)responseItem.SubGroupId,
                        GroupName = responseItem.GroupName,
                        SubGroupName = responseItem.SubGroupName,
                    })
                .ToList();

            result = new PageBaseResponse<List<ResponseModel>>()
            { List = joinedResult, PageNo = response.Data?.PageNo, TotalPage = response?.Data?.TotalPage, TotalCount = response?.Data?.TotalCount };
        }
        else
        {
            result = new PageBaseResponse<List<ResponseModel>>()
            { List = null, PageNo = response.Data?.PageNo, TotalPage = response?.Data?.TotalPage, TotalCount = response?.Data?.TotalCount };
        }
        

        var responseResult = new ApiResponse<PageBaseResponse<List<ResponseModel>>>
        {
            Data = result,
            Code = ApiCodeEnum.Success,
            MsgCode = ApiMessageEnum.Success
        };

        return responseResult;
    }
    #endregion
}

public class ResponseModel
{
    public long UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserPhoto { get; set; }
    public string? NickName { get; set; }
    public long GroupId { get; set; }
    public string? GroupName { get; set; }
    public long SubGroupId { get; set; }
    public string? SubGroupName { get; set; }

}
