using System.Linq.Expressions;
using WebChat.Application.Response;

namespace WebChat.Application.Contracts.Presistence.IBaseRepository;

public interface IBaseRepository<T> where T : class
{
    DbSet<T> Table { get; }
    Task<DbResponse<T>> AddAsync(T entity);
    Task<DbResponse<T>> UpdateAsync(T entity, int updatedBy);
    Task<DbResponse<T>> DeleteAsync(int id, int deletedBy);
    Task<DbResponse<List<T>>> AddMultipleAsync(List<T> entities);
    Task<DbResponse<List<T>>> UpdateMultipleAsync(IEnumerable<T> entities, int updatedBy);
    Task<DbResponse<List<T>>> RemoveRangeAsync(IEnumerable<T> entities);
    Task<DbResponse<bool>> DeletePermanently(T entity);
    Task<DbResponse<T>> GetByIdAsync(int id);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    Task<T?> GetAvailableAsync(int Id);
    Task<IEnumerable<T>> ExecuteSqlQueryAsync(string sqlQuery, params object[] parameters);
    Task<DbResponse<List<T>>> InsertWithSqlAsync(string sqlQuery, params object[] parameters);
    Task<IEnumerable<T>> SelectWithSqlAsync(string sqlQuery, params object[] parameters);
    Task<IEnumerable<T>> FilterWithSqlAsync(string sqlQuery, params object[] parameters);




}
