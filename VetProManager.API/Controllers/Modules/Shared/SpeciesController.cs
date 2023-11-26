﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult InsertSpecies([FromBody] SpeciesDTO dto)
        {
            var response = new ServiceResponse();
            _speciesService.AddAsync(dto);
            
            return Ok(response);

        }
    }
}
