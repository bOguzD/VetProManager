﻿using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository,
            ILogger logger, IMapper mapper, IConfiguration configuration) : base(unitOfWork, repository, logger) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
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
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<User>(dto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _repository.AddAsync(user);

            await _unitOfWork.CommitAsync();

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



        //TODO: Bu kısım ayrı bir service'e taşınabilir
        public async Task LoginAsync(UserDto dto)
        {
            //TODO: validation işlemleri burada yapılmayacak
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(UserDto dto)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, dto.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:SecretKey").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires:DateTime.UtcNow.AddHours(5),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
