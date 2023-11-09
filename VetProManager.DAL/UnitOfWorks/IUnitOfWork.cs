using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Contracts.Modules.CRM;

namespace VetProManager.DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
        void SaveChanges();
        void Rollback();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        ICustomerRepository Customers { get; set; }
        
    }
}
