using MongoDB.Driver;
using WebChat.Application.ApplicationSettings;
using WebChat.Application.Contracts.Presistence.IRepositories;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Presistence.Repositories;

namespace WebChat.Presistence.UnitOfWork;

/// <summary>
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
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _applicationSettings = applicationSettings;
        _configuration = configuration;

        UserRepository = new UserRepository(
            context: _context,
            configuration: _configuration,
            httpContextAccessor: _httpContextAccessor,
            appSettings: _applicationSettings);
    }
    public IUserRepository UserRepository { get; }

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
