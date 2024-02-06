namespace WebChat.Application.Contracts.Presistence.IBaseRepository;

#region IBaseMongoRepository Contract
#region IBaseMongoRepository
/// <summary>
/// IBaseMongoRepository Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <typeparam name="T"></typeparam> 
#endregion
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

#endregion