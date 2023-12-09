﻿using VetProManager.Core.Base;
using VetProManager.Core.Base.Contract;

namespace VetProManager.DAL.Modules.Security {
    public class UserRole : BaseEntity{

        public int UserRoleType { get; set; }
        public virtual User User { get; set; }
    }
}
