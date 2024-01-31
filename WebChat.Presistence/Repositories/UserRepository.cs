using WebChat.Application.ApplicationSettings;
using WebChat.Application.Contracts.Presistence.IRepositories;
using WebChat.Presistence.Repositories.BaseRepository;

namespace WebChat.Presistence.Repositories;

public class UserRepository(
    WebchatDBContext context, 
    IConfiguration configuration, 
    IHttpContextAccessor httpContextAccessor, 
    AppSettings appSettings) : BaseRepository<UserEntity>(
        context, 
        configuration, 
        httpContextAccessor, 
        appSettings), IUserRepository
{
    // Add Custom Function here....
}
