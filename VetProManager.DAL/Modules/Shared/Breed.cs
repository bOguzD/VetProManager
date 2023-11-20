using VetProManager.DAL.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class Breed : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Species Species { get; set; }
    }
}
