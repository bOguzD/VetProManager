﻿using System.Linq.Expressions;
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

        public async Task<UserDTO> GetByIdAsync(long id) {
            var user = await _repository.GetByIdAsync(id);
            var userDTO = _mapper.Map<UserDTO>(user);

            _logger.Information("Kullanıcı bilgisi alındı.  mail adresi: {0}", userDTO.Email);
            return userDTO;
        }

        public async Task<UserDTO> GetUserByEmail(string email) {
            var user = _repository.Where(x => x.Email == email).Result.First();
            if (user == null) {
                _logger.Warning("Kullanıcı bulunamadı. Email adresi {0}", email);
                return null;
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            _logger.Information("Kullanıcı bilgisi alındı.  mail adresi: {0}", userDTO.Email);
            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public IQueryable<UserDTO> GetAllAsQueryable() {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> Where(Expression<Func<UserDTO, bool>> predicate) {
            throw new NotImplementedException();
        }

        public async Task AddAsync(UserDTO entity) {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<UserDTO> entities) {
            throw new NotImplementedException();
        }

        public void Update(UserDTO entity) {
            throw new NotImplementedException();
        }

        public void Delete(UserDTO entity) {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<UserDTO> entities) {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<UserDTO, bool>> predicate) {
            throw new NotImplementedException();
        }
    }
}
