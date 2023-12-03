namespace VetProManager.Core.Base.Contract {
    public interface IBaseEntity {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedUserId { get; set; }
    }
}
