using VetProManager.Core.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class VaccinationType : BaseEntity {
        public int TypeOfVaccination { get; set; }
        public string Description { get; set; }
    }
}
