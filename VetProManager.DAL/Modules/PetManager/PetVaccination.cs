using VetProManager.DAL.Base;
using VetProManager.DAL.Modules.Shared;

namespace VetProManager.DAL.Modules.PetManager {
    public class PetVaccination : TenantEntity {
        public virtual Pet Pet { get; set; }
        public virtual VaccinationType VaccinationType { get; set; }
        public virtual Vaccine Vaccine { get; set; }
        public DateTime VaccinationDate { get; set; }
        public bool IsVaccinated { get; set; }
    }
}
