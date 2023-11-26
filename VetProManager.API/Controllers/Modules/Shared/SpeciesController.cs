using Microsoft.AspNetCore.Mvc;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.Shared;
using VetProManager.Service.Responses;

namespace VetProManager.API.Controllers.Modules.Shared {
    [ApiController]
    [Route("api/species")]
    public class SpeciesController : ControllerBase {

        private readonly SpeciesService _speciesService;

        public SpeciesController(SpeciesService speciesService) {
            _speciesService = speciesService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(long Id) {
            var response = new ServiceResponse() {
                Data = await _speciesService.GetByIdAsync(Id)
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() {
            var response = new ServiceResponse {
                Data = await _speciesService.GetAllAsync()
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertSpecies([FromBody] SpeciesDTO dto) {
            var response = new ServiceResponse();
            await _speciesService.AddAsync(dto);

            return Ok(response);

        }
    }
}
