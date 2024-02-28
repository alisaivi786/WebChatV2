namespace WebChat.Application.Auth;

public class PrincipalAccessor(IHttpContextAccessor httpContextAccessor) : IPrincipalAccessor
{
    public ClaimsPrincipal Principal => HttpContext?.User;

    public HttpContext HttpContext => _httpContextAccessor?.HttpContext;

    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
}

public class StaticPrincipalAccessor : IPrincipalAccessor
{
    private readonly ClaimsPrincipal _principal;
    private readonly HttpContext _httpContext;
    private StaticPrincipalAccessor(HttpContext httpContext)
    {
        _httpContext = httpContext;
        _principal = _httpContext?.User;
    }

    public ClaimsPrincipal Principal => _principal;
    public HttpContext HttpContext => _httpContext;

    public static IPrincipalAccessor CreateInstance(HttpContext httpContext)
    {
        return new StaticPrincipalAccessor(httpContext);
    }
}

public interface IPrincipalAccessor
{
    ClaimsPrincipal Principal { get; }
    HttpContext HttpContext { get; }
}
