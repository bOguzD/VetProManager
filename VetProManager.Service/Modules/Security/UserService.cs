using System.Linq.Expressions;
using AutoMapper;
using Serilog;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Security;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Modules.Security {
    public class UserService : Service<User>, IUserService {

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository, ILogger logger, IMapper mapper) : base(unitOfWork, repository, logger) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> GetByIdAsync(long id) {
            var user = await _repository.GetByIdAsync(id);
            var userDTO = _mapper.Map<UserDto>(user);

            _logger.Information("Kullanıcı bilgisi alındı.  mail adresi: {0}", userDTO.Email);
            return userDTO;
        }

        public async Task<UserDto> GetUserByEmail(string email) {
            var user = _repository.Where(x => x.Email == email).Result.First();
            if (user == null) {
                _logger.Warning("Kullanıcı bulunamadı. Email adresi {0}", email);
                return null;
            }

            var userDTO = _mapper.Map<UserDto>(user);

            _logger.Information("Kullanıcı bilgisi alındı.  mail adresi: {0}", userDTO.Email);
            return userDTO;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public IQueryable<UserDto> GetAllAsQueryable() {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> Where(Expression<Func<UserDto, bool>> predicate) {
            throw new NotImplementedException();
        }

        public async Task AddAsync(UserDto entity) {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<UserDto> entities) {
            throw new NotImplementedException();
        }

        public void Update(UserDto entity) {
            throw new NotImplementedException();
        }

        public void Delete(UserDto entity) {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<UserDto> entities) {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<UserDto, bool>> predicate) {
            throw new NotImplementedException();
        }
    }
}
