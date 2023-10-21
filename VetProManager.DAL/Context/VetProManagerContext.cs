using Microsoft.EntityFrameworkCore;

namespace VetProManager.DAL.Context {
    public class VetProManagerContext : DbContext {
        public VetProManagerContext() { }

        public VetProManagerContext(DbContextOptions<VetProManagerContext> options) : base(options) { }

    }
}
