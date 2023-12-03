﻿using VetProManager.Core.Base.Contract;

namespace VetProManager.Core.Base {
    public class BaseEntity : IBaseEntity {

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedUserId { get; set; }
    }
}
