namespace WebChat.Presistence.UnitOfWork;

/// <summary>
/// UnitOfWork provide base to communicate with database with same context.
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
public class UnitOfWork : IUnitOfWork,IDisposable
{
    private readonly WebchatDBContext _context;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppSettings _applicationSettings;

    public UnitOfWork(
        WebchatDBContext context,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        AppSettings applicationSettings)
    {
        #region Dependencies Init()
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _applicationSettings = applicationSettings;
        _configuration = configuration; 
        #endregion

        #region UserRepository
        UserRepository = new UserRepository(
          context: _context,
          configuration: _configuration,
          httpContextAccessor: _httpContextAccessor,
          appSettings: _applicationSettings);
        #endregion

        #region MessageRepository
        MessageRepository = new MessageRepository(
         context: _context,
         configuration: _configuration,
         httpContextAccessor: _httpContextAccessor,
         appSettings: _applicationSettings);
        #endregion

        #region GroupRepository
        GroupRepository = new GroupRepository(
         context: _context,
         configuration: _configuration,
         httpContextAccessor: _httpContextAccessor,
         appSettings: _applicationSettings);
        #endregion

        #region GroupUserRepository
        GroupUserRepository = new GroupUserRepository(
         context: _context,
         configuration: _configuration,
         httpContextAccessor: _httpContextAccessor,
         appSettings: _applicationSettings);
        #endregion
    }
    public IUserRepository UserRepository { get; }

    public IMessageRepository MessageRepository { get; }
    public IGroupRepository GroupRepository { get; }

    public IGroupUserRepository GroupUserRepository { get; }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose() => _context.Dispose();
}
