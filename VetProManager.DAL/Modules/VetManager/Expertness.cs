using VetProManager.Core.Base;
using VetProManager.DAL.Modules.Shared;

namespace VetProManager.DAL.Modules.VetManager {
    public class Expertness : TenantEntity {
        public virtual Species Species { get; set; }
        public virtual Vet Vet { get; set; }
    }
}
