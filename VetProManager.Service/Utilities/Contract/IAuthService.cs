namespace VetProManager.Service.Utilities.Contract {
    public interface IAuthService {
        string Authenticate(string userName, string password);
    }
}
