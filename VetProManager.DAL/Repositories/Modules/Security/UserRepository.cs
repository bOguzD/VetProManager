using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.Modules.Security;
using VetProManager.DAL.Modules.Security;

namespace VetProManager.DAL.Repositories.Modules.Security {
    public class UserRepository : Repository<User>, IUserRepository {
        public UserRepository(VetProManagerContext context) : base(context) {

        }
    }
}
