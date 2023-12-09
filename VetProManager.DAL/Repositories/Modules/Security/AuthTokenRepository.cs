using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.Modules.Security;
using VetProManager.DAL.Modules.Security;

namespace VetProManager.DAL.Repositories.Modules.Security {
    public class AuthTokenRepository : Repository<AuthToken>, IAuthTokenRepository {
        public AuthTokenRepository(VetProManagerContext context) : base(context) {

        }
    }
}
