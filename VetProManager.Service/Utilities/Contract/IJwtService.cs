namespace VetProManager.Service.Utilities.Contract {
    public interface IJwtService {
        string GenerateToken (long userId, string role);
        string GenerateToken(string email, string role);
    }
}
