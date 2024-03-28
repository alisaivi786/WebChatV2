using JwtService.Interface;
using WebChat.Redis;

namespace WebChat.Presistence.UnitOfWork;

/// <summary>
/// UnitOfWork provide base to communicate with database with same context.
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
public class UnitOfWork : IUnitOfWork,IDisposable
{
    private readonly WebchatDBContext Context;
    private readonly IConfiguration Configuration;
    private readonly IHttpContextAccessor HttpContextAccessor;
    private readonly IAppSettings AppSettings;
    private readonly IAuthService AuthService;
   // private readonly IRedisService RedisService;

    private readonly IRedisService2<object> RedisService2;

    public UnitOfWork(
        WebchatDBContext context,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IAppSettings applicationSettings,
      //  IRedisService redisService,
        IRedisService2<object> redisService2,
        IAuthService authService)
    {
        #region Dependencies Init()
        Context = context;
        HttpContextAccessor = httpContextAccessor;
        AppSettings = applicationSettings;
        Configuration = configuration; 
        AuthService = authService;
      //  RedisService = redisService;
        RedisService2 = redisService2;
        #endregion



        #region MessageRepository
        MessageRepository = new MessageRepository(
         context: Context,
         configuration: Configuration,
         httpContextAccessor: HttpContextAccessor,
         appSettings: AppSettings);
        #endregion

        #region GroupRepository
        GroupRepository = new GroupRepository(
         context: Context,
         configuration: Configuration,
         httpContextAccessor: HttpContextAccessor,
         appSettings: AppSettings);
        #endregion

        #region SubGroupRepository
        SubGroupRepository = new SubGroupRepository(
         context: Context,
         configuration: Configuration,
         httpContextAccessor: HttpContextAccessor,
         appSettings: AppSettings);
        #endregion

        #region GroupUserRepository
        GroupUserRepository = new GroupUserRepository(
         context: Context,
         configuration: Configuration,
         httpContextAccessor: HttpContextAccessor,
         appSettings: AppSettings);
        #endregion

        #region UserRepository
        UserRepository = new UserRepository(
          context: Context,
         configuration: Configuration,
         httpContextAccessor: HttpContextAccessor,
         appSettings: AppSettings,
         authService: AuthService,
        // redisService: RedisService,
         redisService2: RedisService2);
        #endregion
    }
    public IUserRepository UserRepository { get; }

    public IMessageRepository MessageRepository { get; }
    public IGroupRepository GroupRepository { get; }
    public ISubGroupRepository SubGroupRepository { get; }

    public IGroupUserRepository GroupUserRepository { get; }

    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }
    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }
    public void Dispose() => Context.Dispose();
}
