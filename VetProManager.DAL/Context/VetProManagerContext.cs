using Microsoft.EntityFrameworkCore;
using VetProManager.Core.Base;
using VetProManager.DAL.Modules.AppointmentManager;
using VetProManager.DAL.Modules.CRM;
using VetProManager.DAL.Modules.PetManager;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.Modules.VetManager;

namespace VetProManager.DAL.Context {
    public class VetProManagerContext : DbContext {
        public VetProManagerContext() { }

        public VetProManagerContext(DbContextOptions<VetProManagerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=VetProManager;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<PetDetailHistory>()
                .Property(p => p.Weight)
                .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<TenantEntity>().HasIndex(x => x.TenantId);


            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType)) {
                    modelBuilder.Entity(entityType.ClrType).HasKey("Id");
                }

                //if (typeof(TenantEntity).IsAssignableFrom(entityType.ClrType))
                //{
                //    var method = typeof(VetProManagerContext).GetMethod(nameof(ApplyTenantFilterForEntityType))
                //        .MakeGenericMethod(entityType.ClrType);

                //    method.Invoke(this, new object[] { modelBuilder });
                //}


                foreach (var foreignKey in entityType.GetForeignKeys()) {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
            base.OnModelCreating(modelBuilder);
        }

        //private void ApplyTenantFilterForEntityType<TEntity>(ModelBuilder modelBuilder) where TEntity : TenantEntity
        //{
        //    modelBuilder.Entity<TEntity>()
        //        .HasQueryFilter(entity => EF.Property<int>(entity, "TenantId") == 1); //TODO:GetCurrentUserId
        //}




        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetDetailHistory> PetsDetailHistories { get; set; }
        public DbSet<PetOwner> PetsOwners { get; set; }
        public DbSet<PetVaccination> PetsVaccinations { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccinationType> VaccinationTypes { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Expertness> Expertnesses { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<VetClinic> VetClinics { get; set; }

    }
}
