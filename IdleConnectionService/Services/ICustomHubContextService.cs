
namespace IdleConnectionService.Services;

public interface ICustomHubContextService
{
    public Task CheckIdleConnections();
}
