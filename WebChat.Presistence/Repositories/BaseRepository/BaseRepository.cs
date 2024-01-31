#region NameSpace
using MongoDB.Driver;
using WebChat.Application.ApplicationSettings;

namespace WebChat.Presistence.Repositories.BaseRepository;
#endregion

#region BaseRepository
#region BaseRepository Summary Info
/// <summary>
/// Base repository for facilitating communication between entities and the database.
/// This base repository also aids in performing generic operations for all repositories associated with entities.
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="context"></param>
/// <param name="configuration"></param>
/// <param name="httpContextAccessor"></param> 
#endregion
public class BaseRepository<T>(
WebchatDBContext context,
IConfiguration configuration,
IHttpContextAccessor httpContextAccessor,
AppSettings appSettings) : IBaseRepository<T> where T : class
{
    #region Class Level Properties
    private readonly DbContext _context = context;// ?? throw new ArgumentNullException(nameof(context));
    private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    private readonly AppSettings _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
    #endregion

    #region Entity Table
    public DbSet<T> Table { get; set; } = context.Set<T>();
    #endregion

    #region AddAsync
    #region AddAsync Summary
    /// <summary>
    /// Add Entity into Database Using AddAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Return Db Operation Response</returns> 
    #endregion
    public async Task<DbResponse<T>> AddAsync(T entity)
    {
        try
        {
            var e = Table.Add(entity);
            await _context.SaveChangesAsync();

            var dbResponse = new DbResponse<T>()
            {
                Data = e.Entity,
                MsgCode = DbMessageEnums.Inserted,
                Code = DbCodeEnums.Success
            };

            return dbResponse;
        }
        catch (Exception ex)
        {
            // Handle generic exception
            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            return new DbResponse<T>
            {
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
    }
    #endregion

    #region AddMultipleAsync
    #region AddMultipleAsync Summary
    /// <summary>
    /// Add Bulk Insertion into Database using AddMultipleAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="entities"></param>
    /// <returns>Return Db Operation Response</returns> 
    #endregion
    public async Task<DbResponse<List<T>>> AddMultipleAsync(IEnumerable<T> entities)
    {
        #region ...
        try
        {
            Table.AddRange(entities);
            await _context.SaveChangesAsync();

            var response = new DbResponse<List<T>>
            {
                Data = entities.ToList(),
                MsgCode = DbMessageEnums.BulkInserted,
                Code = DbCodeEnums.Success
            };
            return response;
        }
        catch (Exception ex)
        {
            // Handle generic exception
            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            return new DbResponse<List<T>>
            {
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
        #endregion
    }
    #endregion

    #region GetAll
    #region GetAll Summary
    /// <summary>
    /// Get All IQueryable Result Data of Entity using GetAll Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <returns>Return List of Entity Response</returns> 
    #endregion
    public IQueryable<T> GetAll()
    {
        return Table;
    }
    #endregion

    #region Predicate GetAll with where Predicate
    #region GetAll Summary
    /// <summary>
    /// Get All IQueryable Result Data of Entity with predicate using GetAll Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>Return List of Entity Response</returns> 
    #endregion
    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return Table.Where(predicate);
    }
    #endregion

    #region GetAvailableAsync
    #region GetAvailableAsync Summary
    /// <summary>
    /// Get Entity by using Id using GetAvailableAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>Return Entity Result</returns> 
    #endregion
    public async Task<T?> GetAvailableAsync(int Id)
    {
        #region ...
        var response = await Table.FindAsync(Id);
        return response;
        #endregion
    }
    #endregion

    #region GetByIdAsync
    #region GetByIdAsync Summary
    /// <summary>
    /// Get Entity by using Id using GetAvailableAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return Entity Result</returns>  
    #endregion
    public async Task<DbResponse<T>> GetByIdAsync(int id)
    {
        #region ...
        try
        {
            var result = await GetAvailableAsync(id);

            if (result != null)
            {
                var response = new DbResponse<T>
                {
                    Data = result,
                    MsgCode = DbMessageEnums.Fetch,
                    Code = DbCodeEnums.Success
                };
                return response;
            }
            return new DbResponse<T>()
            {
                MsgCode = DbMessageEnums.EntityNotFound,
                Code = DbCodeEnums.Success
            };
        }
        catch (Exception ex)
        {
            // Handle generic exception
            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            return new DbResponse<T>
            {
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
        #endregion
    }
    #endregion

    #region RemoveRangeAsync
    #region RemoveRangeAsync Summary
    /// <summary>
    /// Remove Range of Entities using RemoveRangeAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception> 
    #endregion
    public Task<DbResponse<List<T>>> RemoveRangeAsync(IEnumerable<T> entities)
    {
        #region ...
        throw new NotImplementedException();
        #endregion
    }
    #endregion

    #region UpdateAsync
    #region UpdateAsync Summary
    /// <summary>
    /// Update Single Entity using UpdateAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="updatedBy"></param>
    /// <returns>Return Db Operation Response</returns> 
    #endregion
    public async Task<DbResponse<T>> UpdateAsync(T entity, int updatedBy)
    {
        #region ...
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.ModifiedBy = updatedBy;
            baseEntity.DateModified = DateTime.Now;
        }

        _ = Table.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return new DbResponse<T> { Data = entity, MsgCode = DbMessageEnums.Updated, Code = DbCodeEnums.Success };
        #endregion
    }
    #endregion

    #region UpdateMultipleAsync
    #region UpdateMultipleAsync Summary
    /// <summary>
    /// Update Range of  Entities using UpdateMultipleAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="updatedBy"></param>
    /// <returns></returns> 
    #endregion
    public async Task<DbResponse<List<T>>> UpdateMultipleAsync(IEnumerable<T> entities, int updatedBy)
    {
        #region ...
        try
        {
            foreach (var entity in entities)
            {
                if (entity is BaseEntity baseEntity)
                {
                    baseEntity.ModifiedBy = updatedBy;
                    baseEntity.DateModified = DateTime.Now;
                }
            }

            _ = Table;
            Table.UpdateRange(entities);
            await _context.SaveChangesAsync();

            var response = new DbResponse<List<T>>
            {
                Data = entities.ToList(),
                MsgCode = DbMessageEnums.BulkUpdated,
                Code = DbCodeEnums.Success
            };

            return response;
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, or perform any necessary actions
            var errorResponse = new DbResponse<List<T>>
            {
                MsgCode = DbMessageEnums.FailedPresistence,
                Code = DbCodeEnums.DbException,
                Error = [new ErrorModel { Id = "UpdateMultipleAsync", Message = ex.Message }]
            };

            return errorResponse;
        }
        #endregion
    }
    #endregion

    #region DeleteAsync
    #region DeleteAsync Summary
    /// <summary>
    /// Delete Entity by Id using DeleteAsync Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="id"></param>
    /// <param name="deletedBy"></param>
    /// <returns></returns> 
    #endregion
    public async Task<DbResponse<T>> DeleteAsync(int id, int deletedBy)
    {
        #region ...
        var entity = await GetByIdAsync(id);
        var result = await UpdateAsync(entity.Data, deletedBy);
        if ((int)result.Code == (int)DbCodeEnums.Success)
        {
            return new DbResponse<T> { Data = entity.Data, MsgCode = DbMessageEnums.Deleted, Code = DbCodeEnums.Success };
        }
        return new DbResponse<T> { Data = entity.Data, MsgCode = DbMessageEnums.FailedPresistence, Code = DbCodeEnums.Failed };
        #endregion

    }
    #endregion

    #region DeletePermanently
    #region DeletePermanently Summary
    /// <summary>
    /// DeletePermanently by Providing Entity Record using DeletePermanently Func
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 30-Jan-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Return Db Operation Response</returns> 
    #endregion
    public async Task<DbResponse<bool>> DeletePermanently(T entity)
    {
        #region ...
        try
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();

            return new DbResponse<bool> { Data = true, Code = DbCodeEnums.Success, MsgCode = DbMessageEnums.Deleted };
        }
        catch (Exception ex)
        {
            // Handle generic exception
            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            return new DbResponse<bool>
            {
                Data = false,
                Code = DbCodeEnums.DbException,
                MsgCode = DbMessageEnums.FailedPresistence,
                Error = [genericError]
            };
        }
        #endregion
    }


    #endregion



   
} 
#endregion
