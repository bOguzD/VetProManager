using VetProManager.Core.Base.Contract;

namespace VetProManager.Core.Base {
    public class TenantEntity : BaseEntity, ITenantEntity {
        public long TenantId { get; set; }
    }
}
