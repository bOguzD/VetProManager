using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Xml;
using Microsoft.Identity.Client;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Security;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;
using VetProManager.Service.BaseService.Contract;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.DTOs;
using VetProManager.Service.Responses;
using VetProManager.Service.Validations;
using System.Text;
using VetProManager.Service.Helpers.Exceptions;

namespace VetProManager.Service.Modules.Security {
    public class AccountService : Service<AuthToken>, IAccountService {

        private readonly IRepository<AuthToken> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly AuthTokenValidator _validator;
        private readonly IUserService _userService;

        public AccountService(IUnitOfWork unitOfWork, IRepository<AuthToken> repository,
            ILogger logger, IMapper mapper, AuthTokenValidator validator, IUserService service,
            IConfiguration configuration) : base(unitOfWork, repository, logger) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
            _userService = service;
            _configuration = configuration;
        }

        public async Task LoginAsync(AuthTokenDto dto) {

            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid) {
                _logger.Error("Validasyon hatası. {0}", validationResult.Errors);
                //TODO: throw yapılmadan olacak
                throw new ValidationException(validationResult.Errors);
            }

            //var user = _repository.Where(x => x.User.Email == dto.Email).Result.FirstOrDefault()?.User;
            var user = _userService.GetUserByEmail(dto.Email).Result;

            if (user == null) {
                _logger.Error("Kullanıcı bulunamadı: {0}", dto.Email);
                throw new VetProException($"Kullanıcı bulunamadı: {dto.Email}");
            }

            var userDto = new UserDto()
            {
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Password = dto.Password
            };

            var confirmPassword = VerifyPasswordHash(userDto.Password, userDto.PasswordHash, userDto.PasswordSalt);

            if (confirmPassword)
            {
                var existToken = _repository.Where(x => x.User.Email == user.Email).Result.FirstOrDefault();

                //Eğer mevcut token bilgisi varsa yeni token oluşturmuyor
                if (existToken is not null)
                {
                    existToken.ExpirationDate = DateTime.UtcNow.AddHours(5);
                    _repository.Update(existToken);
                }
                else
                {
                    var authTokenDto = new AuthTokenDto() {
                        ExpirationDate = DateTime.Now.AddHours(5),
                        Email = userDto.Email,
                        //Role = userDto.Role
                    };

                    var token = GenerateToken(authTokenDto);

                    authTokenDto.Token = token;
                    authTokenDto.User = await _userService.GetUserEntityByEmail(userDto.Email);

                    var authToken = _mapper.Map<AuthToken>(authTokenDto);
                    await _repository.AddAsync(authToken);
                }

                await _unitOfWork.CommitAsync();
            }
        }

        public bool ValidateToken(string token) {

            if (string.IsNullOrWhiteSpace(token)) {
                _logger.Error("Token is null");
                return false;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecretKey").Value);

            try {
                var tokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = _configuration.GetSection("Jwt:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                _logger.Information($"Token is valid: {token}");
                return true;
            }
            catch (SecurityTokenExpiredException) {
                _logger.Error("Token süresi geçti: {0}", token);
                return false;
            }
            catch (SecurityTokenInvalidLifetimeException) {
                _logger.Error("Token süresi geçersiz: {0}", token);
                return false;
            }
            catch (SecurityTokenException) {
                _logger.Error("Token doğrulama hatası: {0}", token);
                return false;
            }
            catch (Exception ex) {
                _logger.Error($"Token doğrulama hatası: {token}. Hata: {ex.Message}");
                return false;
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
            using var hmac = new HMACSHA512(passwordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private string GenerateToken(AuthTokenDto dto) {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, dto.Email),
                //new Claim(ClaimTypes.Role, dto.Role),
                new Claim(ClaimTypes.Name,dto.Email),
                new Claim(ClaimTypes.Expiration, dto.ExpirationDate.ToLongDateString()),
                new Claim("unique_Id", Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecretKey").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }




        #region ServiceBaseMethods
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
        #endregion

    }
}
