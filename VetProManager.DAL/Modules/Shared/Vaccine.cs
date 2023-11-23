using VetProManager.Core.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class Vaccine : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public VaccinationType VaccinationType { get; set; }
    }
}
