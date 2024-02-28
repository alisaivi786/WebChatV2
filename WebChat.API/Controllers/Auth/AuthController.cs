namespace WebChat.API.Controllers.Auth;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Auth")]
[ApiController]
public class AuthController(IAuthService authService) : BaseAuthController
{
    public IAuthService AuthService { get; } = authService;

    [AllowAnonymous]
    [HttpPost("AccessToken")]
    public async Task<IActionResult> AccessToken(LoginReqDTO reqest)
    {
        var Token = await UnitOfWork.UserRepository.Login(reqest);
        if(!string.IsNullOrEmpty(Token.ToString()))
        {
            return Ok(new ApiResponse<object>() { Data = new { Token = Token }, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.SuccessToken });
        }
        return Ok(new ApiResponse<object>() { Data = null, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.FailedToken });
    }
   
    [AllowAnonymous]
    [HttpGet("check-token-validity")]
    public async Task<ApiResponse<bool>> CheckTokenValidity([FromQuery] string token)
    {
        bool isValid = await AuthService.ValidateJwtToken2(token);
        ApiResponse<bool>? response;
        if (isValid)
        {
            response = new ApiResponse<bool> { Data = isValid, MsgCode = ApiMessageEnum.ValidToken, Code = ApiCodeEnum.Success };
        }
        else
        {
            response = new ApiResponse<bool> { Data = isValid, MsgCode = ApiMessageEnum.InvalidToken, Code = ApiCodeEnum.Failed };
        }
        return response;
    }
}
