namespace WebChat.Application.Auth;

public interface IClaimsAccessorProvider
{
    IClaimsAccessor? Current { get; set; }
}

public class ClaimsAccessorProvider : IClaimsAccessorProvider
{
    public IClaimsAccessor? Current { get; set; }
    public AsyncLocal<IClaimsAccessor>? AccessorCurrent { get; set; }
}

public class ClaimsAccessor(IPrincipalAccessor principalAccessor) : IdentityUser(principalAccessor), IClaimsAccessor
{
}

public interface IClaimsAccessor : IIdentityUser
{
}
