using VetProManager.DAL.Base;
using VetProManager.DAL.Modules.CRM;

namespace VetProManager.DAL.Modules.PetManager {
    public class PetOwner : TenantEntity {
        public virtual Pet Pet { get; set; }
        public virtual Customer Owner { get; set; }
        public bool IsActive { get; set; }
    }
}
