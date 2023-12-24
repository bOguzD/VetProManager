using VetProManager.DAL.Modules.Security;

namespace VetProManager.Service.DTOs {
    public class AuthTokenDto {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? Token { get; set; }
        public virtual User User { get; set; }
        //public string Role { get; set; }
    }
}
