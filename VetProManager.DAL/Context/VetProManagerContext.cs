using Microsoft.EntityFrameworkCore;
using VetProManager.DAL.Base;
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
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
            //    if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType)) {
            //        modelBuilder.Entity(entityType.ClrType).HasKey("Id");
            //    }
            //}
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetDetailHistory> PetsDetailHistories { get; set; }
        public DbSet<PetOwner> PetsOwners { get; set; }
        public DbSet<PetVaccination> PetsVaccinations { get; set;}
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccinationType> VaccinationTypes { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Expertness> Expertnesses { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<VetClinic> VetClinics { get; set;}

    }
}
