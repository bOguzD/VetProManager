using VetProManager.Core.Base;
using VetProManager.Core.Base.Contract;

namespace VetProManager.DAL.Modules.Security {
    public class User : BaseEntity, ITenantEntity{

        public User() {
            this.Roles = new List<UserRole>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }

        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public long TenantId { get; set; }

        public List<UserRole> Roles { get; set; }
    }
}
