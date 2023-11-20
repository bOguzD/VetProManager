using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetProManager.DAL.Base;

namespace VetProManager.DAL.Modules.PetManager {
    public class PetDetailHistory : TenantEntity{
        public virtual Pet Pet { get; set; }
        public decimal Weight { get; set; }
    }
}
