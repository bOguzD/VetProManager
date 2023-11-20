using VetProManager.DAL.Base;

namespace VetProManager.DAL.Modules.CRM {
    public class Customer: TenantEntity, IAddress {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }  
        public string MobilePhone { get; set; }
    }
}
