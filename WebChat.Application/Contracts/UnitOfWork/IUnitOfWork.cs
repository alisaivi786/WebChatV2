namespace WebChat.Application.Contracts.UnitOfWork;

#region IUnitOfWork Contract 
#region IUnitOfWork Contract Summary
/// <summary>
/// IUnitOfWork Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public interface IUnitOfWork : IDisposable
{

    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }


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

#endregion