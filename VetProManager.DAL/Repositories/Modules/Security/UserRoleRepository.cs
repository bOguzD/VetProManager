using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.Modules.Security;
using VetProManager.DAL.Modules.Security;

namespace VetProManager.DAL.Repositories.Modules.Security {
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository {
        public UserRoleRepository(VetProManagerContext context) : base(context) {
        }
    }
}
