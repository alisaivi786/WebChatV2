using MongoDB.Driver;

namespace WebChat.Presistence.Repositories.BaseRepository;

public class BaseMongoRepository<T>(
    IMongoDatabase database,
    string collectionName) : IBaseMongoRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection = database.GetCollection<T>(collectionName);

    #region Mongo DB Functions
    public async Task<DbResponse<bool>> InsertMongoAsync(T entity)
    {
        try
        {
            await _collection.InsertOneAsync(entity);
            return new DbResponse<bool> { Data = true, Code = DbCodeEnums.Success, MsgCode = DbMessageEnums.Inserted };
        }
        catch (Exception ex)
        {
            var genericError = new ErrorModel { Id = "InsertMongoAsync", Message = ex.Message };
            return new DbResponse<bool>
            {
                Data = false,
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }

    public async Task<DbResponse<bool>> UpdateMongoAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
    {
        try
        {
            await _collection.UpdateOneAsync(filter, update);
            return new DbResponse<bool> { Data = true, Code = DbCodeEnums.Success, MsgCode = DbMessageEnums.Updated };
        }
        catch (Exception ex)
        {
            var genericError = new ErrorModel { Id = "UpdateMongoAsync", Message = ex.Message };
            return new DbResponse<bool>
            {
                Data = false,
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }

    public async Task<DbResponse<bool>> DeleteMongoAsync(Expression<Func<T, bool>> filter)
    {
        try
        {
            await _collection.DeleteOneAsync(filter);
            return new DbResponse<bool> { Data = true, Code = DbCodeEnums.Success, MsgCode = DbMessageEnums.Deleted };
        }
        catch (Exception ex)
        {
            var genericError = new ErrorModel { Id = "DeleteMongoAsync", Message = ex.Message };
            return new DbResponse<bool>
            {
                Data = false,
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }

    public async Task<DbResponse<IEnumerable<T>>> GetAllMongoAsync()
    {
        try
        {
            var entities = await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
            return new DbResponse<IEnumerable<T>> { Data = entities, MsgCode = DbMessageEnums.FetchAll, Code = DbCodeEnums.Success};
        }
        catch (Exception ex)
        {
            var genericError = new ErrorModel { Id = "GetAllMongoAsync", Message = ex.Message };
            return new DbResponse<IEnumerable<T>>
            {
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }

    public async Task<DbResponse<IEnumerable<T>>> GetMongoAsync(Expression<Func<T, bool>> filter)
    {
        try
        {
            var entities = await _collection.Find(filter).ToListAsync();
            return new DbResponse<IEnumerable<T>> { Data = entities, MsgCode = DbMessageEnums.Fetch, Code = DbCodeEnums.Success };
        }
        catch (Exception ex)
        {
            var genericError = new ErrorModel { Id = "GetMongoAsync", Message = ex.Message };
            return new DbResponse<IEnumerable<T>>
            {
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }

    public async Task<DbResponse<T>> GetSingleMongoAsync(Expression<Func<T, bool>> filter)
    {
        try
        {
            var entity = await _collection.Find(filter).FirstOrDefaultAsync();
            return new DbResponse<T> { Data = entity, MsgCode = DbMessageEnums.Fetch,Code = DbCodeEnums.Success };
        }
        catch (Exception ex)
        {
            var genericError = new ErrorModel { Id = "GetSingleMongoAsync", Message = ex.Message };
            return new DbResponse<T>
            {
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }
    #endregion
}
