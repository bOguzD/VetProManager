using System.Linq.Expressions;

namespace VetProManager.DAL.Contracts.BaseContracts {
    public interface IRepository<T> where T : class {
        Task<T?> GetByIdAsync(long Id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
