using Microsoft.EntityFrameworkCore.Storage;
using VetProManager.DAL.Context;

namespace VetProManager.DAL.UnitOfWorks {
    public class UnitOfWork : IUnitOfWork {
        private readonly VetProManagerContext _context;
        private readonly IDbContextTransaction _transaction;

        public UnitOfWork(VetProManagerContext context) {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitAsync() {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                //TODO: hata global hale getirilmeli.
                throw new Exception("Bir hata oluştu: " + ex.Message);
            }
           
        }

        public async Task RollbackAsync() {
            await _transaction.RollbackAsync();
        }

        public void SaveChanges() {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public void Rollback() {
            _transaction.Rollback();
        }

        public void Dispose() {
            _transaction.Dispose();
            _context.Dispose();
        }
    }
}
