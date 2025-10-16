using HospitalAppointment.Models;
using Microsoft.EntityFrameworkCore;

public class Appointment_BookingContext : DbContext
{
    public Appointment_BookingContext(DbContextOptions<Appointment_BookingContext> options)
        : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Location> Location { get; set; } = default!;
    public DbSet<Rating> Ratings { get; set; }
   // public DbSet<User> Users { get; set; }
    //public DbSet<Patient> Patients { get; set; }

    public DbSet<MedicalHist> MedicalHist { get; set; }
  //  public DbSet<Patient> Patient { get; set; }
  //  public DbSet<Doctor> Doctor { get; set; }
   // public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalHist>()
            .HasOne(m => m.Patient)
            .WithMany()
            .HasForeignKey(m => m.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MedicalHist>()
            .HasOne(m => m.Doctor)
            .WithMany()
            .HasForeignKey(m => m.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Doctor>()
    //        .HasMany(d => d.Rating)
    //        .WithOne(r => r.Doctor)
    //        .HasForeignKey(r => r.DoctorId);

    //    base.OnModelCreating(modelBuilder);
    //}
    public DbSet<Availability> Availability { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Patient> Patients { get; set; }
    
}