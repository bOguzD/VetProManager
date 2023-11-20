using VetProManager.DAL.Base;
using VetProManager.DAL.Modules.PetManager;
using VetProManager.DAL.Modules.VetManager;

namespace VetProManager.DAL.Modules.AppointmentManager {
    public class Appointment : TenantEntity {
        public virtual Pet Pet { get; set; }
        public virtual VetClinic VetClinic { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsDone { get; set; }
    }
}
