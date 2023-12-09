using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Security;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;
using VetProManager.Service.BaseService.Contract;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.DTOs;
using VetProManager.Service.Responses;
using VetProManager.Service.Validations;

namespace VetProManager.Service.Modules.Security {
    public class AccountService : Service<AuthToken>, IAccountService {
        
        private readonly IRepository<AuthToken> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly AuthTokenValidator _validator;

        public AccountService(IUnitOfWork unitOfWork, IRepository<AuthToken> repository,
            ILogger logger, IMapper mapper, AuthTokenValidator validator) : base(unitOfWork, repository, logger)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResponse> RegisterAsync(AuthTokenDto dto) {
            var response = new ServiceResponse();

            try {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = _mapper.Map<User>(dto);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;



                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex) {
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        //TODO: Bu kısım ayrı bir service'e taşınabilir
        public async Task<ServiceResponse> LoginAsync(AuthTokenDto dto) {
            var response = new ServiceResponse();

            try {
                var validationResult = await _validator.ValidateAsync(dto);

                if (!validationResult.IsValid) {
                    _logger.Error("Validasyon hatası. {0}", validationResult.Errors);
                    //TODO: throw yapılmadan olacak
                    response.Errors.Add(validationResult.Errors.ToString());
                    throw new ValidationException(validationResult.Errors);
                }

                var user = _repository.Where(x => x.User.Email == dto.Email);

                if (user == null) {
                    _logger.Error("Kullanıcı bulunamadı: {0}", dto.Email);
                    response.Errors.Add("Kullanıcı bulunamadı");
                }

            }
            catch (Exception ex) {
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
            using var hmac = new HMACSHA512(passwordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private string GenerateToken(AuthTokenDto dto) {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, dto.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:SecretKey").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        Task<AuthTokenDto> IService<AuthTokenDto>.GetByIdAsync(long Id) {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AuthTokenDto>> IService<AuthTokenDto>.GetAllAsync() {
            throw new NotImplementedException();
        }

        IQueryable<AuthTokenDto> IService<AuthTokenDto>.GetAllAsQueryable() {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthTokenDto>> Where(Expression<Func<AuthTokenDto, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task AddAsync(AuthTokenDto entity) {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<AuthTokenDto> entities) {
            throw new NotImplementedException();
        }

        public void Update(AuthTokenDto entity) {
            throw new NotImplementedException();
        }

        public void Delete(AuthTokenDto entity) {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<AuthTokenDto> entities) {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<AuthTokenDto, bool>> predicate) {
            throw new NotImplementedException();
        }
    }
}
