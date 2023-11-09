using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.Modules.CRM;
using VetProManager.DAL.Modules.CRM;

namespace VetProManager.DAL.Repositories.Modules.CRM {
    public class CustomerRepository : Repository<Customer>, ICustomerRepository {

        public CustomerRepository(VetProManagerContext context) : base(context) { }
    }
}
