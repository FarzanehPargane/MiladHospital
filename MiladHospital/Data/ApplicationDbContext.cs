
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiladHospital.Models.Doctor;
using MiladHospital.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiladHospital.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual  DbSet<Doctor> Doctors { get; set; }
        public virtual  DbSet<Specialty> Specialties { get; set; }
        public virtual  DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentReservation> AppointmentReservation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder./*H*/asAnnotation("Relational:Collation", "Arabic_CI_AS");

            //builder.Entity<Appointment>(entity =>
            //{
            //    entity.Property(e => e.Active)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.ReserveDate).HasColumnType("datetime");

            //    entity.HasOne(d => d.Doctor)
            //        .WithMany(p => p.Appointments)
            //        .HasForeignKey(d => d.DoctorId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Appointments_Doctors");
            //});

            //builder.Entity<AppointmentReservation>(entity =>
            //{
            //    entity.ToTable("AppointmentReservation");

            //    entity.Property(e => e.Mellicode)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mobile)
            //        .HasMaxLength(11)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(30);

            //    entity.Property(e => e.RegisterDate).HasColumnType("datetime");

            //    entity.Property(e => e.Surname)
            //        .IsRequired()
            //        .HasMaxLength(30);

            //    entity.Property(e => e.TrackingCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Appointment)
            //        .WithMany(p => p.AppointmentReservations)
            //        .HasForeignKey(d => d.AppointmentId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AppointmentReservation_Appointments");
            //});

            //builder.Entity<Doctor>(entity =>
            //{
            //    entity.Property(e => e.Mellicode)
            //        .HasMaxLength(10)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Mobile)
            //        .HasMaxLength(11)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(30);

            //    entity.Property(e => e.Surname)
            //        .IsRequired()
            //        .HasMaxLength(30);

            //    entity.HasOne(d => d.Specialty)
            //        .WithMany(p => p.Doctors)
            //        .HasForeignKey(d => d.SpecialtyId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Doctors_Specialties");
            //});

            //builder.Entity<Specialty>(entity =>
            //{
            //    entity.Property(e => e.Field)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});


            //builder.Entity<Specialty>().HasData(
            //     new Specialty() { Id = 1, Field = "زنان، زایمان" },
            //     new Specialty() { Id = 2, Field = "چشم پزشک" },
            //     new Specialty() { Id = 3, Field = "مغز و اعصاب" },
            //     new Specialty() { Id = 4, Field = "روانپزشک" });

            //builder.Entity<Doctor>().HasData(
            //    new Doctor() { Id = 1, SpecialtyId = 1, Name = "نسرین", Surname = "مقتدایی", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 2, SpecialtyId = 1, Name = "آرزو", Surname = "پناهی", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 3, SpecialtyId = 2, Name = "جواد", Surname = "فرهمند", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 4, SpecialtyId = 2, Name = "سینا", Surname = "اکبری", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 5, SpecialtyId = 3, Name = "نادر", Surname = "سلیمانی", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 6, SpecialtyId = 3, Name = "علی", Surname = "افشار", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 7, SpecialtyId = 4, Name = "الهام", Surname = "نوری", Mellicode = "", Mobile = "" },
            //    new Doctor() { Id = 8, SpecialtyId = 4, Name = "کیان", Surname = "عسگری", Mellicode = "", Mobile = "" });
            //builder.Entity<Appointment>().HasData(
            //   new Appointment() { Id = 1, DoctorId = 1, ReserveDate = Convert.ToDateTime("2023-02-20 00:00:00.000"), StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("12:00:00"), Capacity = 50, UsedCapacity = 2, Active = true },
            //   new Appointment() { Id = 2, DoctorId = 2, ReserveDate = Convert.ToDateTime("2023-02-21 00:00:00.000"), StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("13:00:00"), Capacity = 60, UsedCapacity = 0, Active = true },
            //   new Appointment() { Id = 3, DoctorId = 3, ReserveDate = Convert.ToDateTime("2023-02-20 00:00:00.000"), StartTime = TimeSpan.Parse("14:00:00"), EndTime = TimeSpan.Parse("17:00:00"), Capacity = 70, UsedCapacity = 0, Active = true },
            //   new Appointment() { Id = 4, DoctorId = 4, ReserveDate = Convert.ToDateTime("2023-02-22 00:00:00.000"), StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("12:00:00"), Capacity = 50, UsedCapacity = 0, Active = true },
            //   new Appointment() { Id = 5, DoctorId = 5, ReserveDate = Convert.ToDateTime("2023-02-23 00:00:00.000"), StartTime = TimeSpan.Parse("17:00:00"), EndTime = TimeSpan.Parse("20:00:00"), Capacity = 50, UsedCapacity = 0, Active = true },
            //   new Appointment() { Id = 6, DoctorId = 6, ReserveDate = Convert.ToDateTime("2023-02-23 00:00:00.000"), StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("15:00:00"), Capacity = 30, UsedCapacity = 0, Active = true },
            //   new Appointment() { Id = 7, DoctorId = 7, ReserveDate = Convert.ToDateTime("2023-02-24 00:00:00.000"), StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("15:00:00"), Capacity = 40, UsedCapacity = 0, Active = true },
            //   new Appointment() { Id = 8, DoctorId = 8, ReserveDate = Convert.ToDateTime("2023-02-25 00:00:00.000"), StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("11:00:00"), Capacity = 30, UsedCapacity = 0, Active = true });
        }



    }
}
