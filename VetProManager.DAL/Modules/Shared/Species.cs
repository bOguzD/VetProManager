using VetProManager.DAL.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class Species : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
