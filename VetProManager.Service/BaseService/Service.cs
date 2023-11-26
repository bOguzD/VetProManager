using System.Linq.Expressions;
using FluentValidation;
using VetProManager.Core.Base;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService.Contract;

namespace VetProManager.Service.BaseService {
    public class Service<T> : IService<T> where T : class {

        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator _validator;
       // private readonly IUserContext _contextUser;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository/*, IUserContext contextUser*/) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            //_contextUser = contextUser;
        }

        public async Task<T?> GetByIdAsync(int Id) {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _repository.GetAllAsync();
        }

        public IQueryable<T> GetAllAsQueryable() {
            return _repository.GetAllAsQueryable();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate) {
            return await _repository.Where(predicate);
        }

        public async Task AddAsync(T entity) {

            if (entity is TenantEntity tenantEntity) {
               // tenantEntity.TenantId = _contextUser.GetCurrentTenantId();
            }

            await _repository.AddAsync(entity);
            _unitOfWork.SaveChanges();

        }

        public async Task AddRangeAsync(IEnumerable<T> entities) {
            await _repository.AddRangeAsync(entities);
            _unitOfWork.SaveChanges();
        }

        public void Update(T entity) {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Delete(T entity) {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities) {
            _repository.DeleteRange(entities);
            _unitOfWork.SaveChanges();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) {
            return await _repository.AnyAsync(predicate);
        }
    }
}
