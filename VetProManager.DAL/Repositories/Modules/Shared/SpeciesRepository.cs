using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Shared;

namespace VetProManager.DAL.Repositories.Modules.Shared {
    public class SpeciesRepository : Repository<Species>, IRepository<Species> {
        public SpeciesRepository(VetProManagerContext context) : base(context)
        {
        }
    }
}
