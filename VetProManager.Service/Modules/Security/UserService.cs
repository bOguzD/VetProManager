using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Security;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.DTOs;
using VetProManager.Service.Responses;
using VetProManager.Service.Validations;

namespace VetProManager.Service.Modules.Security {
    public class UserService : Service<User>, IUserService {

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly UserValidator _validator;

        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository,
            ILogger logger, IMapper mapper, IConfiguration configuration, UserValidator validator) : base(unitOfWork, repository, logger) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
            _validator = validator;
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

        public async Task AddAsync(UserDto dto) {
            //TODO: burası aslında kullanılmayacak. AuthToken yeterli.
            //TODO: ayrıca update dışında gerek de yok şimdilik
            //var response = new ServiceResponse();

            //try
            //{
            //    var validationResult = await _validator.ValidateAsync(dto);

            //    if (!validationResult.IsValid) {
            //        _logger.Error("Validasyon hatası. {0}", validationResult.Errors);
            //        //TODO: throw yapılmadan olacak
            //        response.Errors.Add(validationResult.Errors.ToString());
            //        throw new ValidationException(validationResult.Errors);
            //    }

            //    var user = _mapper.Map<User>(dto);

            //}
            //catch (Exception ex)
            //{
            //    response.Errors.Add(ex.Message);
            //}

            //await _repository.AddAsync(user);

            //await _unitOfWork.CommitAsync();

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
