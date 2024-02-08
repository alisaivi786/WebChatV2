using System.Threading;

namespace WebChat.Application.Contracts.Presistence.IBaseRepository;

#region IBaseRepository Summary
/// <summary>
/// IBaseRepository Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <typeparam name="T"></typeparam> 
#endregion
public interface IBaseRepository<T> where T : class
{
    DbSet<T> Table { get; }
    protected Task<DbResponse<T>> AddAsync(T entity, CancellationToken cancellationToken = default);
    protected Task<DbResponse<T>> UpdateAsync(T entity, long updatedBy, CancellationToken cancellationToken = default);
    protected Task<DbResponse<T>> DeleteAsync(long id, long deletedBy, CancellationToken cancellationToken = default);
    protected Task<DbResponse<List<T>>> AddMultipleAsync(List<T> entities, CancellationToken cancellationToken = default);
    protected Task<DbResponse<List<T>>> UpdateMultipleAsync(IEnumerable<T> entities, long updatedBy, CancellationToken cancellationToken = default);
    protected Task<DbResponse<List<T>>> RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    protected Task<DbResponse<bool>> DeletePermanentlyAsync(T entity, CancellationToken cancellationToken = default);
    protected Task<DbResponse<T>> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    protected IQueryable<T> GetAll();
    protected IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    protected Task<T?> GetAvailableAsync(long Id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> ExecuteSqlQueryAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters);
    Task<DbResponse<List<T>>> InsertWithSqlAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters);
    Task<IEnumerable<T>> SelectWithSqlAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters);
    Task<IEnumerable<T>> FilterWithSqlAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters);
    Task<PageBaseResponse<List<T>>> GetPagedAsync(int page, int pageSize, Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);




}
