using Microsoft.AspNetCore.Mvc;
using VetProManager.API.Models;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.Security;
using VetProManager.Service.Responses;

namespace VetProManager.API.Controllers.Modules.Security {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService) {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel model) {
            var response = new ServiceResponse();

            try {
                var dto = new AuthTokenDto {
                    Email = model.Email,
                    Password = model.Password
                };

               response = await _accountService.RegisterAsync(dto);

               if (!response.IsSuccess)
                   return BadRequest(response);
            }
            catch (Exception ex) {
                response.Errors.Add(ex.Message);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model) {
            var response = new ServiceResponse();

            try
            {
                var dto = new AuthTokenDto {
                    Email = model.Email,
                    Password = model.Password,
                    Token = model.Token
                };

                await _accountService.LoginAsync(dto);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return Ok(response);
        }
    }
}
