using System.Linq.Expressions;
using WebChat.Application.Response;

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
    protected Task<DbResponse<T>> AddAsync(T entity);
    protected Task<DbResponse<T>> UpdateAsync(T entity, long updatedBy);
    protected Task<DbResponse<T>> DeleteAsync(long id, long deletedBy);
    protected Task<DbResponse<List<T>>> AddMultipleAsync(List<T> entities);
    protected Task<DbResponse<List<T>>> UpdateMultipleAsync(IEnumerable<T> entities, long updatedBy);
    protected Task<DbResponse<List<T>>> RemoveRangeAsync(IEnumerable<T> entities);
    protected Task<DbResponse<bool>> DeletePermanentlyAsync(T entity);
    protected Task<DbResponse<T>> GetByIdAsync(long id);
    protected IQueryable<T> GetAll();
    protected IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    protected Task<T?> GetAvailableAsync(long Id);
    Task<IEnumerable<T>> ExecuteSqlQueryAsync(string sqlQuery, params object[] parameters);
    Task<DbResponse<List<T>>> InsertWithSqlAsync(string sqlQuery, params object[] parameters);
    Task<IEnumerable<T>> SelectWithSqlAsync(string sqlQuery, params object[] parameters);
    Task<IEnumerable<T>> FilterWithSqlAsync(string sqlQuery, params object[] parameters);




}
