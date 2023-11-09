using VetProManager.DAL.Contracts.Modules.CRM;
using VetProManager.DAL.Modules.CRM;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;

namespace VetProManager.Service.Modules.CRM {
    public class CustomerService : Service<Customer>
    {
        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
