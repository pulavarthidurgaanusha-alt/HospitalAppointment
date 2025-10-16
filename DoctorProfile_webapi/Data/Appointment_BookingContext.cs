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
    public DbSet<Rating> Rating { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Availability> Availability { get; set; }
    public DbSet<Patient> Patients { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    {

    //        modelBuilder.Entity<Availability>()
    //        .HasOne(a => a.Location)
    //        .WithMany(l => l.availability)
    //        .HasForeignKey(a => a.LocationId)
    //        .OnDelete(DeleteBehavior.Restrict); 
    //    }
    //}
}
    