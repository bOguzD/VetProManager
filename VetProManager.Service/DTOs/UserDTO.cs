namespace VetProManager.Service.DTOs {
    public class UserDto {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public string Token { get; set; }
    }
}
