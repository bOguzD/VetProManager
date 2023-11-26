using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using Serilog;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.BaseService;
using VetProManager.Service.Contract.Modules.Shared;
using VetProManager.Service.DTOs;
using VetProManager.Service.Responses;
using VetProManager.Service.Validations;

namespace VetProManager.Service.Modules.Shared {
    public class SpeciesService : Service<Species>, ISpeciesService {

        private readonly IMapper _mapper;
        private readonly SpeciesValidator _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Species> _repository;
        private readonly ILogger _logger;
        public SpeciesService(IUnitOfWork unitOfWork, IRepository<Species> repository, IMapper mapper, SpeciesValidator validator, ILogger logger) : base(unitOfWork, repository) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<SpeciesDTO?> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SpeciesDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SpeciesDTO> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SpeciesDTO>> Where(Expression<Func<SpeciesDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(SpeciesDTO entity)
        {
            //TODO: response yapısı generic olarak her yerde gösterilecek
            var response = new ServiceResponse();
            try
            {
                var validationResult = _validator.Validate(entity);

                if (!validationResult.IsValid) 
                    throw new ValidationException(validationResult.Errors);
                

                var speciesEntity = _mapper.Map<Species>(entity);

                await _repository.AddAsync(speciesEntity);
                _unitOfWork.SaveChanges();
                _logger.Information("Kayıt başarılı. {0}", entity.Name);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }

           // return response;
        }

        public async Task AddRangeAsync(IEnumerable<SpeciesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(SpeciesDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SpeciesDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<SpeciesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<SpeciesDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
