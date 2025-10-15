using HospitalAppointment.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Doctor
{
    [Key]
    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required, MinLength(3), MaxLength(100)]
    [Column("name")]
    public string Name { get; set; }

    [StringLength(10)]
    [Column("phone")]
    public string Phone { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required, MaxLength(100)]
    [Column("specialization")]
    public string Specialization { get; set; }

    [Required]
    [Column("experience_years")]
    public int ExperienceYears { get; set; }

    [Required, MaxLength(200)]
    [Column("qualification")]
    public string Qualification { get; set; }

    [Required]
    [Column("gender")]
    public DoctorGender Gender { get; set; }

    // Navigation property for related locations
    public ICollection<Location> Locations { get; set; }
    public ICollection<Rating> Rating { get; set; }
    public enum DoctorGender
    {
        Male,
        Female,
        Other
    }
}

