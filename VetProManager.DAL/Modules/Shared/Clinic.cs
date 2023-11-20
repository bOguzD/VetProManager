using VetProManager.DAL.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class Clinic : BaseEntity, IAddress{
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
    }
}
