using VetProManager.DAL.Modules.Security;
using VetProManager.Service.BaseService.Contract;
using VetProManager.Service.DTOs;
using VetProManager.Service.Responses;

namespace VetProManager.Service.Contract.Modules.Security {
    public interface IAccountService : IService<AuthTokenDto> {
        public Task<ServiceResponse> LoginAsync(AuthTokenDto dto);
       

    }
}
