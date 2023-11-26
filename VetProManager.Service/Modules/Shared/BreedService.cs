using Serilog;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;

namespace VetProManager.Service.Modules.Shared {
    public class BreedService : Service<Breed> {
        public BreedService(IUnitOfWork unitOfWork, IRepository<Breed> repository, ILogger logger) : base(unitOfWork, repository, logger)
        {
        }
    }
}
