using VetProManager.Core.Base;

namespace VetProManager.DAL.Modules.Shared {
    public class Clinic : BaseEntity, IAddressEntity{
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
    }
}
