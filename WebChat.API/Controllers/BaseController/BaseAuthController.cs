using WebChat.Redis;

namespace WebChat.API.Controllers.BaseController;

[Authorize]
[ApiController]
public class BaseAuthController : ControllerBase
{
    //
    protected IClaimsAccessor? CurrentUser => GetCurrentUser();
    private IClaimsAccessor? GetCurrentUser() =>
        // Resolve the implementation using the built-in DI container
        HttpContext.RequestServices.GetService<IClaimsAccessor>();

    // Property for injecting IUnitOfWork
    protected IUnitOfWork UnitOfWork
    {
        get
        {
            // Resolve the implementation using the built-in DI container
            return HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
        }
    }
    //protected IRedisService RedisService
    //{
    //    get
    //    {
    //        // Resolve the implementation using the built-in DI container
    //        return HttpContext.RequestServices.GetRequiredService<IRedisService>();
    //    }
    //} 
    protected IAppSettings AppSettings
    {
        get
        {
            // Resolve the implementation using the built-in DI container
            return HttpContext.RequestServices.GetRequiredService<IAppSettings>();
        }
    }
    protected IWebHostEnvironment Environment
    {
        get
        {
            // Resolve the implementation using the built-in DI container
            return HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
        }
    }
}

