using Microsoft.AspNetCore.Mvc;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.Shared;

namespace VetProManager.API.Controllers.Modules.Shared {
    [ApiController]
    [Route("api/species")]
    public class SpeciesController : ControllerBase {

        private readonly SpeciesService _speciesService;

        public SpeciesController(SpeciesService speciesService) {
            _speciesService = speciesService;
        }

        [HttpPost]
        public IActionResult InsertSpecies([FromBody] SpeciesDTO dto)
        {
            _speciesService.AddAsync(dto);

            return Ok();

        }
    }
}
