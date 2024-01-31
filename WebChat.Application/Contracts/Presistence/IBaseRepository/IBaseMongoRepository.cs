using MongoDB.Driver;
using System.Linq.Expressions;
using WebChat.Application.Response;

namespace WebChat.Application.Contracts.Presistence.IBaseRepository;

public interface IBaseMongoRepository<T> where T : class
{
    // Mongo DB Function:
    Task<DbResponse<bool>> InsertMongoAsync(T entity);
    Task<DbResponse<bool>> UpdateMongoAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update);
    Task<DbResponse<bool>> DeleteMongoAsync(Expression<Func<T, bool>> filter);
    Task<DbResponse<IEnumerable<T>>> GetAllMongoAsync();
    Task<DbResponse<IEnumerable<T>>> GetMongoAsync(Expression<Func<T, bool>> filter);
    Task<DbResponse<T>> GetSingleMongoAsync(Expression<Func<T, bool>> filter);
}
