using VetProManager.DAL.Modules.Security;
using VetProManager.Service.BaseService.Contract;
using VetProManager.Service.Responses;

namespace VetProManager.Service.Contract.Modules.Security {
    public interface IAccounService : IService<AuthToken> {
        public Task<ServiceResponse> LoginAsync(AuthToken dto);
        public Task<ServiceResponse> RegisterAsync(AuthToken dto);

    }
}
