using VetProManager.DAL.Base;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.Modules.VetManager;

namespace VetProManager.DAL.Modules.AppointmentManager {
    public class Examination : TenantEntity {
        public virtual Appointment Appointment { get; set; }
        public DateTime ExaminationDate { get; set; }
        public virtual Vet Vet { get; set; }
        public virtual Clinic Clinic { get; set; }

    }
}
