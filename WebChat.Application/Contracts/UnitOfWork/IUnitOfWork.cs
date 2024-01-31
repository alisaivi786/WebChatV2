using WebChat.Application.Contracts.Presistence.IRepositories;

namespace WebChat.Application.Contracts.UnitOfWork;

public interface IUnitOfWork : IDisposable
{

    IUserRepository UserRepository { get; }


    /// <summary>
    /// Asynchronously saves changes to the underlying database.
    /// </summary>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task SaveAsync();

    /// <summary>
    /// Asynchronously saves changes to the underlying database and returns the number of objects saved.
    /// </summary>
    /// <returns>A task representing the asynchronous save operation and the number of objects saved.</returns>
    Task<int> SaveChangesAsync();
}
