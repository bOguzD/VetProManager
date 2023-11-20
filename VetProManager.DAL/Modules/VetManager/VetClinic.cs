using VetProManager.DAL.Base;
using VetProManager.DAL.Modules.Shared;

namespace VetProManager.DAL.Modules.VetManager {
    public class VetClinic : TenantEntity {
        public virtual Vet Vet { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
