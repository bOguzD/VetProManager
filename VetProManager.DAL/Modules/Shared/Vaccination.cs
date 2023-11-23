using VetProManager.Core.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class Vaccination : BaseEntity {
        public virtual Species Species { get; set; }
        public virtual Vaccine Vaccine { get; set; }
    }
}
