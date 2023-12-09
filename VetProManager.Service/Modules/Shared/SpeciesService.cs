﻿using System.Linq.Expressions;
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

        public SpeciesService(IUnitOfWork unitOfWork, IRepository<Species> repository, ILogger logger, IMapper mapper, SpeciesValidator validator) : base(unitOfWork, repository, logger) {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<SpeciesDto?> GetByIdAsync(long id)
        {
            try
            {
                var species = await _repository.GetByIdAsync(id);
                var speciesDTO = _mapper.Map<SpeciesDto>(species);

                _logger.Information("Tür bilgisi alındı. {0}", speciesDTO.Code);

                return speciesDTO;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw ex;
            }

        }

        public async Task<IEnumerable<SpeciesDto>> GetAllAsync()
        {
            var speciesList = await _repository.GetAllAsync();

            var speciesListDTO = new List<SpeciesDto>();
            if (speciesList.Any()) {
                speciesListDTO = _mapper.Map<IEnumerable<SpeciesDto>>(speciesList).ToList();
            }

            _logger.Information("Tür bilgileri çekildi.");

            return speciesListDTO;
        }

        public IQueryable<SpeciesDto> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SpeciesDto>> Where(Expression<Func<SpeciesDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(SpeciesDto entity)
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
                _logger.Error("Hata Mesajı: {0}", ex.Message);
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }

           //return response;
        }

        public async Task AddRangeAsync(IEnumerable<SpeciesDto> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(SpeciesDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SpeciesDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<SpeciesDto> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<SpeciesDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
