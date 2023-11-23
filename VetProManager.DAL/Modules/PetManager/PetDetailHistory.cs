using VetProManager.Core.Base;

namespace VetProManager.DAL.Modules.PetManager {
    public class PetDetailHistory : TenantEntity{
        public virtual Pet Pet { get; set; }
        public decimal Weight { get; set; }
    }
}
