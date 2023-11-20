using System.ComponentModel.DataAnnotations;

namespace VetProManager.DAL.Base {
    public class BaseEntity {

        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedUserId { get; set; }
    }
}
