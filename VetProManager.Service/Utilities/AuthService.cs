using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetProManager.Service.Contract.Modules.Security;
using VetProManager.Service.Utilities.Contract;

namespace VetProManager.Service.Utilities {
    public class AuthService : IAuthService {

        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthService(IUserService userService, IJwtService jwtService) {
            _userService = userService;
            _jwtService = jwtService;
        }

        public string Authenticate(string userName, string password) {
            // Kullanıcı doğrulama işlemleri burada gerçekleştirilir

            // Kullanıcı bilgileri doğruysa token oluştur
            //var user = _userService.GetUserByUserName(userName);
            //if (user != null && _userService.VerifyPassword(user, password)) {
            //    var role = "Admin"; // Kullanıcının rolü
            //    var token = _jwtService.GenerateToken(user.Id, user.UserName, role);
            //    return token;
            //}

            return null;
        }
    }
}
