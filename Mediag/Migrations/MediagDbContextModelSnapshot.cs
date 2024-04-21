﻿// <auto-generated />
using System;
using Mediag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mediag.Migrations
{
    [DbContext(typeof(MediagDbContext))]
    partial class MediagDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mediag.Models.BreastCancerData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("AreaWorst")
                        .HasColumnType("float");

                    b.Property<double>("ConcavePointsMean")
                        .HasColumnType("float");

                    b.Property<double>("ConcavePointsWorst")
                        .HasColumnType("float");

                    b.Property<long?>("MedicalFileId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<double>("PerimeterMean")
                        .HasColumnType("float");

                    b.Property<double>("PerimeterWorst")
                        .HasColumnType("float");

                    b.Property<double>("RadiusWorst")
                        .HasColumnType("float");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MedicalFileId");

                    b.ToTable("BreastCancerDatas");
                });

            modelBuilder.Entity("Mediag.Models.ChestPainTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ChestPainTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Typical angina"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Atypical angina"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Non anginal pain"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Asymptomatic"
                        });
                });

            modelBuilder.Entity("Mediag.Models.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("HospitalId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialism")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Mediag.Models.Hospital", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "City")
                        .IsUnique();

                    b.ToTable("Hospitals");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "Montréal",
                            Name = "Hôpital général de Montréal"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Greenfield Park",
                            Name = "Hôpital Charles-Le Moyne"
                        },
                        new
                        {
                            Id = 3L,
                            City = "Victoriaville",
                            Name = "Hôtel-Dieu d'Arthabaska"
                        });
                });

            modelBuilder.Entity("Mediag.Models.IllnessTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("IllnessTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Breast cancer"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Heart disease"
                        });
                });

            modelBuilder.Entity("Mediag.Models.MedicalFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<long?>("HospitalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<long>("TargetIllnessId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TargetIllnessId");

                    b.ToTable("MedicalFiles");
                });

            modelBuilder.Entity("Mediag.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("HospitalId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Mediag.Models.ThalassemiaTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ThalassemiaTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Strange"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Normal"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Fixed"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Reversable"
                        });
                });

            modelBuilder.Entity("Mediag.Models.BreastCancerData", b =>
                {
                    b.HasOne("Mediag.Models.MedicalFile", "MedicalFile")
                        .WithMany()
                        .HasForeignKey("MedicalFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalFile");
                });

            modelBuilder.Entity("Mediag.Models.Doctor", b =>
                {
                    b.HasOne("Mediag.Models.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("Mediag.Models.MedicalFile", b =>
                {
                    b.HasOne("Mediag.Models.Doctor", "Doctor")
                        .WithMany("MedicalFiles")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mediag.Models.Hospital", "Hospital")
                        .WithMany("MedicalFiles")
                        .HasForeignKey("HospitalId");

                    b.HasOne("Mediag.Models.Patient", "Patient")
                        .WithMany("MedicalFiles")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mediag.Models.IllnessTypes", "TargetIllness")
                        .WithMany()
                        .HasForeignKey("TargetIllnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Hospital");

                    b.Navigation("Patient");

                    b.Navigation("TargetIllness");
                });

            modelBuilder.Entity("Mediag.Models.Patient", b =>
                {
                    b.HasOne("Mediag.Models.Hospital", "Hospital")
                        .WithMany("Patients")
                        .HasForeignKey("HospitalId");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("Mediag.Models.Doctor", b =>
                {
                    b.Navigation("MedicalFiles");
                });

            modelBuilder.Entity("Mediag.Models.Hospital", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("MedicalFiles");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Mediag.Models.Patient", b =>
                {
                    b.Navigation("MedicalFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
