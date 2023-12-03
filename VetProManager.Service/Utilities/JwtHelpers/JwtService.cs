using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.Utilities.Contract;

namespace VetProManager.Service.Utilities.JwtHelpers {
    public class JwtService : IJwtService {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration, IUserService userService) {
            _userService = userService;
            _configuration = configuration;
        }

        public string GenerateToken(long userId, string role) {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(string email, string role)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null) {
                // Kullanıcı bulunamazsa gerekli işlemleri yapabilirsiniz.
                return null;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Result.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
