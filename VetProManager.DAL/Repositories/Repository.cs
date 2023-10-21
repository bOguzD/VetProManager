using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.BaseContracts;

namespace VetProManager.DAL.Repositories {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        private readonly VetProManagerContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(VetProManagerContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity) {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.AnyAsync(predicate);
        }

        public void Delete(TEntity entity) {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities) {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAllAsQueryable() {
            return _dbSet.AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int Id) {
            return await _dbSet.FindAsync(Id);
        }

        public void Update(TEntity entity) {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
