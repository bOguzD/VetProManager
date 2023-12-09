using VetProManager.Service.BaseService.Contract;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Contract.Modules.Security {
    public interface IUserService : IService<UserDto> {
        public Task<UserDto> GetUserByEmail(string email);
    }
}
