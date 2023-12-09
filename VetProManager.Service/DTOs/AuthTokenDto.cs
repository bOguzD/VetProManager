namespace VetProManager.Service.DTOs {
    public class AuthTokenDto {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public string Token { get; set; }
    }
}
