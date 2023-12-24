using VetProManager.Core.Base;

namespace VetProManager.DAL.Modules.Security {
    public class AuthToken : BaseEntity {
        public DateTime ExpirationDate { get; set; }
        public string Token { get; set; }
        public virtual User User { get; set; }
        //public string Role { get; set; }
    }
}
