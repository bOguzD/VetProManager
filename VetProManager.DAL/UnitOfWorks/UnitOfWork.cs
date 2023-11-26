using Microsoft.EntityFrameworkCore.Storage;
using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Contracts.Modules.CRM;
using VetProManager.DAL.Repositories;

namespace VetProManager.DAL.UnitOfWorks {
    public class UnitOfWork : IUnitOfWork {
        private readonly VetProManagerContext _context;
        private readonly IDbContextTransaction _transaction;
        public ICustomerRepository Customers { get; set; }

        public UnitOfWork(VetProManagerContext context, ICustomerRepository customers) {
            _context = context;
            Customers = customers;
            _transaction = _context.Database.BeginTransaction();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class {
            return new Repository<TEntity>(_context);
        }

        public async Task CommitAsync() {
            try {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception ex) {
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

            //try {
            //    // Eğer _transaction ve _context null değilse, dispose işlemlerini gerçekleştir
            //    _transaction?.Dispose();

            //    if (_context != null) {
            //        // Eğer _context üzerinde açık bir veri okuyucusu varsa, kapat
            //        if (_context.Database.CurrentTransaction != null) {
            //            if (_context.Database.CurrentTransaction.GetDbTransaction().Connection != null) {
            //                if (_context.Database.CurrentTransaction.GetDbTransaction().Connection.State == System.Data.ConnectionState.Open) {
            //                    _context.Database.CurrentTransaction.GetDbTransaction().Connection.Close();
            //                }
            //            }
            //        }

            //        _context.Dispose();
            //    }
            //}
            //catch (Exception ex) {
            //    Console.WriteLine("Dispose işlemi sırasında hata oluştu: " + ex.Message);
            //}

            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
