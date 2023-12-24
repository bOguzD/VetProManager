using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetProManager.API.Models;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.DTOs;
using VetProManager.Service.Helpers.Exceptions;
using VetProManager.Service.Responses;

namespace VetProManager.API.Controllers.Modules.Security {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {

        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService) {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel model) {
            var response = new ServiceResponse();

            try {
                var dto = new UserDto() {
                    Email = model.Email,
                    Password = model.Password
                };

                await _userService.AddAsync(dto);

            }
            catch (Exception ex) {
                response.Errors.Add(ex.InnerException?.Message);
                throw new VetProException(ex.Message, ex.InnerException);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model) {
            var response = new ServiceResponse();

            try {

                var isValidToken = _accountService.ValidateToken(model.Token);

                if (isValidToken) {
                    response.Message = $"Login successful: {model.Token}";

                } else {
                    var dto = new AuthTokenDto {
                        Email = model.Email,
                        Password = model.Password,
                        Token = model.Token
                    };

                    await _accountService.LoginAsync(dto);
                }

            }
            catch (Exception ex) {
                response.Errors.Add(ex.Message);
            }

            return Ok(response);
        }
    }
}
