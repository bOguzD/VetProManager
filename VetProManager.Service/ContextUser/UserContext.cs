namespace VetProManager.Service.ContextUser {
    public class UserContext : IUserContext {

        public long GetCurrentTenantId() {
            //TODO: Kullanıcının oturum bilgilerini veya başka bir mekanizmayı kullanarak TenantId bilgisini al
            return 1;
        }
    }
}
