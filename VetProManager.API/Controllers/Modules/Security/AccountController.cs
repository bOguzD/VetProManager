using Microsoft.AspNetCore.Mvc;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.Security;
using VetProManager.Service.Responses;

namespace VetProManager.API.Controllers.Modules.Security {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {

        private readonly AccountService _accountService;

        public AccountController(UserService userService) {

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(AuthTokenDto dto) {
            var response = new ServiceResponse();

            await _accountService.RegisterAsync(dto);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthTokenDto dto) {
            var response = new ServiceResponse();

            await _accountService.LoginAsync(dto);

            return Ok(response);
        }
    }
}
