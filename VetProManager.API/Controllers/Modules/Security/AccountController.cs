using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.Security;
using VetProManager.Service.Responses;

namespace VetProManager.API.Controllers.Modules.Security {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {

        private readonly UserService _userService;

        public AccountController(UserService userService)
        {

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto dto)
        {
            var response = new ServiceResponse();
            
            await _userService.RegisterAsync(dto);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserDto dto)
        {
            var response = new ServiceResponse();

            await _userService.LoginAsync(dto);

            return Ok(response);
        }
    }
}
