namespace VetProManager.DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
        void SaveChanges();
        void Rollback();
    }
}
