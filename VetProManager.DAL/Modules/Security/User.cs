using Microsoft.AspNetCore.Identity;

namespace VetProManager.DAL.Modules.Security {
    public class User : IdentityUser {

        public User() {
            this.Roles = new List<IdentityRole>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string DisplayName { get; set; }


        public bool IsActive { get; set; }
        public long TenantId { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}
