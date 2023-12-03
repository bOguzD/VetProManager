namespace VetProManager.Service.Utilities.Contract {
    public interface IJwtService {
        string GenerateToken (long UserId, string Role);
    }
}
