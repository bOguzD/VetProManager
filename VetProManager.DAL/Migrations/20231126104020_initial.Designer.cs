﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetProManager.DAL.Context;

#nullable disable

namespace VetProManager.DAL.Migrations
{
    [DbContext(typeof(VetProManagerContext))]
    [Migration("20231126104020_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VetProManager.DAL.Modules.AppointmentManager.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<long>("PetId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VetClinicId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("VetClinicId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.AppointmentManager.Examination", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppointmentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClinicId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ExaminationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("VetId");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.CRM.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("BreedId")
                        .HasColumnType("bigint");

                    b.Property<string>("ChipNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsChipped")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEscaped")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.PetDetailHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("PetId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("PetsDetailHistories");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.PetOwner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("PetId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetId");

                    b.ToTable("PetsOwners");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.PetVaccination", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("bit");

                    b.Property<long>("PetId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("VaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("VaccinationTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("VaccineId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("VaccinationTypeId");

                    b.HasIndex("VaccineId");

                    b.ToTable("PetsVaccinations");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Breed", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SpeciesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Clinic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Species", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Vaccination", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("SpeciesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VaccineId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.VaccinationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfVaccination")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("VaccinationTypes");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Vaccine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VaccinationTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VaccinationTypeId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.VetManager.Expertness", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("SpeciesId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("VetId");

                    b.ToTable("Expertnesses");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.VetManager.Vet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmployedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.VetManager.VetClinic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ClinicId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("VetId");

                    b.ToTable("VetClinics");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.AppointmentManager.Appointment", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.PetManager.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.VetManager.VetClinic", "VetClinic")
                        .WithMany()
                        .HasForeignKey("VetClinicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("VetClinic");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.AppointmentManager.Examination", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.AppointmentManager.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.Shared.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.VetManager.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Clinic");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.Pet", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.Shared.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.PetDetailHistory", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.PetManager.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.PetOwner", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.CRM.Customer", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.PetManager.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.PetManager.PetVaccination", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.PetManager.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.Shared.VaccinationType", "VaccinationType")
                        .WithMany()
                        .HasForeignKey("VaccinationTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.Shared.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("VaccinationType");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Breed", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.Shared.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Vaccination", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.Shared.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.Shared.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Species");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.Shared.Vaccine", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.Shared.VaccinationType", "VaccinationType")
                        .WithMany()
                        .HasForeignKey("VaccinationTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("VaccinationType");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.VetManager.Expertness", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.Shared.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.VetManager.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Species");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("VetProManager.DAL.Modules.VetManager.VetClinic", b =>
                {
                    b.HasOne("VetProManager.DAL.Modules.Shared.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VetProManager.DAL.Modules.VetManager.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Vet");
                });
#pragma warning restore 612, 618
        }
    }
}
