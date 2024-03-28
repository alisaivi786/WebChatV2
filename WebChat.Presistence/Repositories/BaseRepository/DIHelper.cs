using Microsoft.Extensions.DependencyInjection;
using WebChat.Redis;

namespace WebChat.Presistence.Repositories.BaseRepository;


public class DIHelper(IServiceProvider serviceProvider)
{
    protected IServiceProvider ServiceProvider { get; } = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    //protected IRedisService RedisService
    //{
    //    get => ServiceProvider.GetRequiredService<IRedisService>();
    //}
}

