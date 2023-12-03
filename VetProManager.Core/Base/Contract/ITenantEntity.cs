using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetProManager.Core.Base.Contract {
    public interface ITenantEntity : IBaseEntity{
        public long TenantId { get; set; }
    }
}
