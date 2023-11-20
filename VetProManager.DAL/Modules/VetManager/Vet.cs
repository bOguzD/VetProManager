using VetProManager.DAL.Base;

namespace VetProManager.DAL.Modules.VetManager {
    public class Vet : TenantEntity {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public bool IsActive { get; set; }
        public DateTime EmployedDate { get; set; }
    }
}
