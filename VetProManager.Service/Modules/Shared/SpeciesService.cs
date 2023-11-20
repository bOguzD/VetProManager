using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;

namespace VetProManager.Service.Modules.Shared {
    public class SpeciesService : Service<Species> {
        public SpeciesService(IUnitOfWork unitOfWork, IRepository<Species> repository) : base(unitOfWork, repository) {
        }
    }
}
