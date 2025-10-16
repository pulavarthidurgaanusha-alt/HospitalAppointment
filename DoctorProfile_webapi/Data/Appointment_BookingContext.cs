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
    public DbSet<Patient> Patient { get; set; }
    
}