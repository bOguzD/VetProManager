using VetProManager.DAL.Contracts.Modules.CRM;
using VetProManager.DAL.Modules.CRM;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;
using VetProManager.Service.Contract.Modules;

namespace VetProManager.Service.Modules.CRM {
    public class CustomerService : Service<Customer>, ICustomerService {
        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository repository) : base(unitOfWork, repository) {
        }
    }
}
