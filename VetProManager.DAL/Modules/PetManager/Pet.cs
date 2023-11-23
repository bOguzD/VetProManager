using VetProManager.Core.Base;
using VetProManager.DAL.Modules.Shared;

namespace VetProManager.DAL.Modules.PetManager {
    public class Pet :TenantEntity {
        public string Name { get; set; }
        public virtual Breed Breed { get; set; }
        public DateTime BirthDate { get; set; }
        
        //TODO:Enum setlemesi yapılacak
        public int Gender { get; set; }
        public bool IsAlive { get; set; } = true;
        public bool IsEscaped { get; set; } = false;
        public bool IsChipped { get; set; }
        public string ChipNumber { get; set; }
    }
}
